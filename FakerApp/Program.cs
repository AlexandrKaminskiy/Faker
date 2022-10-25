using Faker;
using Faker.Interfaces;
using System;
using System.Text.Json;

namespace FakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IFaker faker = new Faker.Faker();
            var temp = faker.Create<Car>();
            var json = JsonSerializer.Serialize(temp, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(json);
        }
    }
}
