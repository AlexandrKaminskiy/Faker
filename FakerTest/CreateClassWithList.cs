using Xunit;
using Faker;
using UnitTests.TestClasses;

namespace UnitTests
{
    public class CreateClassWithList
    {
        private Faker.Faker _faker = new Faker.Faker();
        [Fact]
        public void CreateClassWithValueList()
        {
            //Arrange

            //Act
            var temp = _faker.Create<ClassWithValueList>();
            //Assert
            Assert.NotNull(temp);
        }

        [Fact]
        public void CreateClassWithRefList()
        {
            //Arrange

            //Act
            var temp = _faker.Create<ClassWithRefList>();
            //Assert
            Assert.NotNull(temp);
        }
    }
}