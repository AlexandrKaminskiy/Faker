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

            var temp = faker.Create<TestClass>();
            var json = JsonSerializer.Serialize(temp, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(json);
        }
    }
}
public class TestClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public B b { get; set; }
    public TestClass()
    {
        Id = 12;

    }
}
public class B
{
    public string A;
}