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
        private Dictionary<Type, IGenerator> _generators = new Dictionary<Type, IGenerator>();

        public DefaultGenerator()
        {
            _generators.Add(typeof(int), new IntGenerator());
            _generators.Add(typeof(double), new DoubleGenerator());
            _generators.Add(typeof(DateTime), new DateGenerator());
            _generators.Add(typeof(bool), new BoolGenerator());

            SetGeneratorsFromPlugins();
        }

        private void SetGeneratorsFromPlugins()
        {
            string pathToAdvancedGeneratorsDll = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\");
            string[] allDll = Directory.GetFiles(pathToAdvancedGeneratorsDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator generator = (IGenerator)Activator.CreateInstance(type);
                        _generators.Add(generator.GetGeneratedType(), generator);
                    }
                }
            }
        }
        public bool IsConsistGenerator(Type type)
        {
            return _generators.ContainsKey(type);
        }
        public object? Generate(Type type)
        {
            if (IsConsistGenerator(type))
                return _generators[type].Generate();
            else
                return null;
        }

    }
}
