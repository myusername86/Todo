using System;
using System.Linq;
using Todo.Models;
using Todo.Data;
using Xunit;

namespace TestTodo_service
{
    public class TestTodo_service
    {
        [Fact]
        public void Size_ShouldReturnZero_WhenNoTodos()
        {
            //Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state

            // Act
            int size = service.Size();

            // Assert
            Assert.Equal(0, size);

        }
        [Fact]
        public void Size_ShouldReturnCorrectNumberOfTodos()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            service.CreateItem("Test todo 1");
            service.CreateItem("Test todo 2");

            // Act
            int size = service.Size();

            // Assert
            Assert.Equal(2, size);
        }
        [Fact]
        public void FindAll_ShouldReturnAllTodos()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            service.CreateItem("Test todo 1");
            service.CreateItem("Test todo 2");

            // Act
            var todos = service.FindAll();

            // Assert
            Assert.Equal(2, todos.Length);
        }
        [Fact]
        public void FindById_ShouldReturnCorrectTodo()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            var todo = service.CreateItem("Test todo 1");

            // Act
            var foundTodo = service.FindById(todo.Id);

            // Assert
            Assert.Equal(todo.Id, foundTodo.Id);
        }
        [Fact]
        public void CreateItem_ShouldAddNewItem()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            int initialSize = service.Size();

            // Act
            var newTodo = service.CreateItem("Test todo 1");
            int newSize = service.Size();

            // Assert
            Assert.NotEqual(initialSize, newSize);
            Assert.Equal(initialSize + 1, newSize);
            Assert.Equal("Test todo 1", newTodo.Description);
        }
        [Fact]
        public void Clear_ShouldRemoveAllTodos()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            service.CreateItem("Test todo 1");

            // Act
            service.clear();
            int size = service.Size();

            // Assert
            Assert.Equal(0, size);
        }
        [Fact]
        public void FindByDoneStatus_ShouldReturnMatchingTodos()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            var todo1 = service.CreateItem("Test todo 1");
            todo1.Done = true;
            var todo2 = service.CreateItem("Test todo 2");
            todo2.Done = false;

            // Act
            var doneTodos = service.FindByDoneStatus(true);
            var notDoneTodos = service.FindByDoneStatus(false);

            // Assert
            Assert.Single(doneTodos);
            Assert.Equal(todo1.Id, doneTodos[0].Id);
            Assert.Single(notDoneTodos);
            Assert.Equal(todo2.Id, notDoneTodos[0].Id);
        }

        [Fact]
        public void FindByAssignee_ShouldReturnMatchingTodosByPersonId()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            var assignee = new Person(Personsequencer.NextPersonId(), "John", "Doe");
            var todo1 = service.CreateItem("Test todo 1");
            todo1.Assignee = assignee;
            var todo2 = service.CreateItem("Test todo 2");

            // Act
            var assignedTodos = service.FindByAssignee(assignee.Id);

            // Assert
            Assert.Single(assignedTodos);
            Assert.Equal(todo1.Id, assignedTodos[0].Id);
        }

        [Fact]
        public void FindByAssignee_ShouldReturnMatchingTodosByPerson()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            var assignee = new Person(Personsequencer.NextPersonId(), "John", "Doe");
            var todo1 = service.CreateItem("Test todo 1");
            todo1.Assignee = assignee;
            var todo2 = service.CreateItem("Test todo 2");

            // Act
            var assignedTodos = service.FindByAssignee(assignee);

            // Assert
            Assert.Single(assignedTodos);
            Assert.Equal(todo1.Id, assignedTodos[0].Id);
        }

        [Fact]
        public void FindUnassignedTodoItems_ShouldReturnTodosWithNoAssignee()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            var assignee = new Person(Personsequencer.NextPersonId(), "John", "Doe");
            var todo1 = service.CreateItem("Test todo 1");
            todo1.Assignee = assignee;
            var todo2 = service.CreateItem("Test todo 2");

            // Act
            var unassignedTodos = service.FindUnassignedTodoItems();

            // Assert
            Assert.Single(unassignedTodos);
            Assert.Equal(todo2.Id, unassignedTodos[0].Id);
        }

        [Fact]
        public void Remove_ShouldReturnTrueAndRemoveTodo_WhenTodoExists()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state
            var todo = service.CreateItem("Test todo");

            // Act
            bool result = service.Remove(todo.Id);
            int sizeAfterRemove = service.Size();

            // Assert
            Assert.True(result);
            Assert.Equal(0, sizeAfterRemove);
            Assert.Null(service.FindById(todo.Id));
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenTodoDoesNotExist()
        {
            // Arrange
            var service = new Todoservice();
            service.clear(); // Ensure starting from a known state

            // Act
            bool result = service.Remove(999); // ID that doesn't exist

            // Assert
            Assert.False(result);
        }
    }
}





    
