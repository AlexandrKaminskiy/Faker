using Faker.Generators;
using Faker.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class DefaultGenerator
    {
        private Dictionary<Type, IGenerator> valueGenerateDictionary = new Dictionary<Type, IGenerator>();
        public bool hasGenerator(Type type)
        {
            return valueGenerateDictionary.ContainsKey(type);
        }
        public object Generate(Type type)
        {
            if (hasGenerator(type))
            {
                return valueGenerateDictionary[type].Generate();
            }
            return null;
        }
        public DefaultGenerator()
        {
            valueGenerateDictionary.Add(typeof(int), new IntGenerator());
            valueGenerateDictionary.Add(typeof(double), new DoubleGenerator());
            valueGenerateDictionary.Add(typeof(DateTime), new DateGenerator());
            valueGenerateDictionary.Add(typeof(bool), new BoolGenerator());
            AddPluginGenerators();
        }

        private void AddPluginGenerators()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\");
            string[] dlls = Directory.GetFiles(path, "*.dll");
            foreach (string dll in dlls)
            {
                Assembly asm = Assembly.LoadFrom(dll);
                foreach (var type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator generator = (IGenerator)Activator.CreateInstance(type);
                        valueGenerateDictionary.Add(generator.GetGeneratedType(), generator);
                    }
                }
            }
        }


    }
}
