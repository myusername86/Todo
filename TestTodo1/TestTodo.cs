using System;
using Todo.Models;
using Xunit;
namespace TestTodo1
{
    public class TestTodo
    {
        [Fact]
        public void Constructor_initialize()
        {
            //Arrange
            int expectedId = 1;
            string expectedDescription = "Finish Assignment1";

            //Act
            Todo1 todo = new Todo1(expectedId, expectedDescription);

            //Assert
            Assert.Equal(expectedId, todo.Id);

            Assert.Equal(expectedDescription, todo.Description);

            Assert.False(todo.Done);

          

        }

        [Fact]
        public void Description_update()
        {
            //Arrange
            Todo1 todo = new Todo1(1, "Initial Description");
            string expectedDescription = "updated Description";
            //Act
            todo.Description = expectedDescription;

            //Assert
            Assert.Equal(expectedDescription, todo.Description);


        }




    }
}