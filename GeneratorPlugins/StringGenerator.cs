using Faker.Interfaces;
using System;

namespace GeneratorsPlugin
{
    public class StringGenerator : IGenerator
    {
        public object Generate()
        {
            return "default string";
        }

        public Type GetGeneratedType()
        {
            return typeof(string);
        }
    }
}
