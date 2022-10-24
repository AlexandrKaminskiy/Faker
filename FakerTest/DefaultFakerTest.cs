using Xunit;
using Faker;
using UnitTests.TestClasses;

namespace UnitTests
{
    public class DefaultFakerTest
    {
        private Faker.Faker _faker = new Faker.Faker();
        [Fact]
        public void CreateDefaultClass()
        {
            var temp = _faker.Create<A>();
            Assert.NotNull(temp);
        }
        
        [Fact]
        public void CreateInsertedClass()
        {
            var temp = _faker.Create<B>();
            Assert.NotNull(temp);
        }
    }
}