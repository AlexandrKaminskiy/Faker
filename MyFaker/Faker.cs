using Faker.Interfaces;
using MyFaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker
{
    public class Faker : IFaker
    {
        private DefaultGenerator defaultGenerator;
        private List<Type> createdUserTypes;
        public T Create<T>()
        {
            defaultGenerator = new DefaultGenerator();
            createdUserTypes = new List<Type>();
            return (T) CreateDto(typeof(T));
        }
        private object CreateDto(Type type)
        {
            bool isSystem = false;
            if(defaultGenerator.hasGenerator(type))
            {
                isSystem = true;
                return defaultGenerator.Generate(type)!;
            }
            if (type.IsGenericType)
            {
                isSystem = true;
                var collection = (IList) Activator.CreateInstance(type);
                var collectionParametrizedType = type.GetGenericArguments()[0];
                collection.Add(CreateDto(collectionParametrizedType));
                collection.Add(CreateDto(collectionParametrizedType));
                return collection;
            }
            if (!createdUserTypes.Contains(type))
            {
                if (!isSystem)
                {
                    createdUserTypes.Add(type);
                }
                var createdObj = CreateObject(type);
                InitializePropsAndFields(createdObj);
                createdUserTypes.Remove(type);
                return createdObj;
            }    
            throw new CyclicException();
        }

        private void InitializePropsAndFields(object obj)
        {
            var properties = obj.GetType().GetProperties();
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var fd = CreateDto(field.FieldType);
                field.SetValue(obj, fd);
            }
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var pr = CreateDto(property.PropertyType);
                    property.SetValue(obj, pr);
                }
            }
        }
        private ConstructorInfo GetConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            var constructor = constructors.OrderBy(c => c.GetParameters().Length).FirstOrDefault();
            return constructor;
        }
        private object CreateObject(Type type)
        {
            var constructor = GetConstructor(type);
            var constructorParametrs = constructor.GetParameters();
            var paramsList = new List<object>(); 
            foreach(var parameter in constructorParametrs)
            {
                paramsList.Add(CreateDto(parameter.ParameterType));
            }
            return constructor.Invoke(paramsList.ToArray());
        }
    }
}
