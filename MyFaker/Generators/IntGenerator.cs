using Faker.Interfaces;
using System;

public class IntGenerator: IGenerator
{
    public object Generate()
    {
        return new Random().Next();
    }

    public Type GetGeneratedType()
    {
        return typeof(int);
    }
}