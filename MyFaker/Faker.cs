using Faker.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker
{
    public class Faker : IFaker
    {
        private DefaultGenerator _generator = new DefaultGenerator();
        private List<Type> _stackTypes;
        public T Create<T>()
        {
            _stackTypes = new List<Type>();
            return (T)CreateDto(typeof(T));
        }
        private object CreateDto(Type type)
        {
            bool isSystem = false;
            if(_generator.IsConsistGenerator(type))
            {
                isSystem = true;
                return _generator.Generate(type)!;
            }
            if (type.IsGenericType)
            {
                isSystem = true;
                var generic = (IList) Activator.CreateInstance(type);
                var genericItemsType = type.GetGenericArguments()[0];
                for(int i = 0; i < 2; i++)
                {
                    var itemObj = CreateDto(genericItemsType);
                    generic.Add(itemObj);
                }
                return generic;
            }
            if (!_stackTypes.Contains(type))
            {
                if (!isSystem)
                {
                    _stackTypes.Add(type);
                }
                var createdObj = CreateObject(type);
                InitializePropsAndFields(createdObj);
                _stackTypes.Remove(type);
                return createdObj;
            }
            else
            {
                //if exist cyclic dependency 
                throw new Exception("exist cyclic dependency");
            }
        }

        private void InitializePropsAndFields(object obj)
        {
            var props = obj.GetType().GetProperties();
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Static |
               BindingFlags.Instance);
            foreach (var field in fields)
            {
                var fd = CreateDto(field.FieldType);
                field.SetValue(obj, fd);
            }
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                {
                    var pr = CreateDto(prop.PropertyType);
                    prop.SetValue(obj, pr);
                }
               
            }
        }

        private object CreateObject(Type type)
        {
            var ctor = GetConstructorWithMinParameters(type);
            if(ctor == null)
            {
                return CreateObject(type);
            }
            var ctorParams = ctor.GetParameters();
            var paramsList = new List<object>(); 
            foreach(var param in ctorParams)
            {
                paramsList.Add(CreateDto(param.ParameterType));
            }
            return ctor.Invoke(paramsList.ToArray());
        }

        private ConstructorInfo? GetConstructorWithMinParameters(Type type)
        {
            var constructors = type.GetConstructors();
            var ctor = constructors.OrderBy(c=>c.GetParameters().Length).FirstOrDefault();
            return ctor;
        }
    }
}
