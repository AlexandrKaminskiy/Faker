using Xunit;
using Faker;
using UnitTests.TestClasses;

namespace UnitTests
{
    public class CreateDefaultClasses
    {
        private Faker.Faker _faker = new Faker.Faker();
        [Fact]
        public void CreateDefaultClass()
        {
            //Arrange

            //Act
            var temp = _faker.Create<NormalClassA>();
            //Assert
            Assert.NotNull(temp);
        }
        
        [Fact]
        public void CreateInsertedClass()
        {
            //Arrange

            //Act
            var temp = _faker.Create<NormalClassB>();
            //Assert
            Assert.NotNull(temp);
        }
    }
}