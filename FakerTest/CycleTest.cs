using Xunit;
using Faker.Interfaces;
using UnitTests.TestClasses;

namespace UnitTests
{
    public class CycleTest
    {
        private Faker.Faker _faker = new Faker.Faker();

        [Fact]
        public void CreateObjectWithCycleFalse()
        {
            try
            {
                var temp = _faker.Create<ACycle>();
                //need to thrown exception
                Assert.True(false);
            }
            catch
            {
                Assert.True(true); 
            }           

        }
    }
}
