using Xunit;
using Faker.Interfaces;
using UnitTests.TestClasses;
namespace UnitTests
{
    public class CheckCtors
    {
        private readonly Faker.Faker _faker = new Faker.Faker();
        [Fact]
        public void CreateClassWithManyCtors()
        {
            //rrange
            //Act
            var temp = _faker.Create<ManyCtors>();
            //Assert
            Assert.True(temp.Value);
        }
    }
}
