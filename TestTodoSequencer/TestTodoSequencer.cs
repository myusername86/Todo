using Xunit;
using Todo.Data;
namespace TestTodoSequencer
{
    public class TestTodoSequencer
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            TodoSequencer.Reset();
            //Act
            int firstId = TodoSequencer.NextTodoId();

            int secondId = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(1, firstId);

            Assert.Equal(2, secondId);


        }
        [Fact]
        public void ResetIdToZero()
        {
            //Arrange
            TodoSequencer.Reset();
            TodoSequencer.NextTodoId();
            //Act
            TodoSequencer.Reset();
            int newId = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(1, newId);

        }
    }
}