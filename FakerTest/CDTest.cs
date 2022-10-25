using Xunit;
using Faker.Interfaces;
using UnitTests.TestClasses;
using System;
using MyFaker;

namespace UnitTests
{
    public class CDTest
    {
        private Faker.Faker _faker = new Faker.Faker();

        [Fact]
        public void CyclicDependencies()
        {
            Assert.Throws<CyclicException>(() => _faker.Create<ACD>());
        }
    }
}
