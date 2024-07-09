using Todo.Data;
using Xunit;
namespace TestPersonsequencer
{
    public class Testsequencer
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Personsequencer.Reset();
            //Act
            int firstId = Personsequencer.NextPersonId();

            int secondId = Personsequencer.NextPersonId();

            //Assert
            Assert.Equal(1, firstId);

            Assert.Equal(2, secondId);

        }
        [Fact]
        public void ResetIdToZero()
        {
            //Arrange
            Personsequencer.Reset();
            Personsequencer.NextPersonId();
            //Act
            Personsequencer.Reset();
            int newId = Personsequencer.NextPersonId();

            //Assert
            Assert.Equal(1, newId);

        }
    }
}