using Xunit;
using Faker;
using UnitTests.TestClasses;

namespace UnitTests
{
    public class ListTest
    {
        private Faker.Faker _faker = new Faker.Faker();
        [Fact]
        public void CreateClassWithValueList()
        {
            var temp = _faker.Create<ValList>();
            Assert.NotNull(temp);
        }

        [Fact]
        public void CreateClassWithRefList()
        {
            var temp = _faker.Create<AList>();
            Assert.NotNull(temp);
        }
    }
}