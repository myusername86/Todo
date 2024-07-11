using Todo.Data;
using Todo.Models;
using Xunit;
using System;
using System.Linq;

namespace TestTodoService2
{
    public class TestTodoService2
    {
        [Fact]
              
            public void Size_ShouldReturnZero_WhenNoTodoItemsAdded()
            {
                // Arrange
                TodoService service = new TodoService();
                service.clear(); // Ensure starting from a known state

                // Act
                int size = service.Size();

                // Assert
                Assert.Equal(0, size);
            }
        [Fact]
        public void FindAll_ShouldReturnEmptyArray_WhenNoTodoItemsAdded()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); // Ensure starting from a known state

            // Act
            Todo1[] allTodos = service.FindAll();

            // Assert
            Assert.Empty(allTodos);
        }
        [Fact]
        public void CreateTodo_ShouldAddTodoToTheArray()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); // Ensure starting from a known state

            // Act
            Todo1 todo = service.CreateTodo("Test todo");

            // Assert
            Assert.NotNull(todo);
            Assert.Equal(1, service.Size());
            Assert.Contains(todo, service.FindAll());
        }
        [Fact]
        public void FindById_ShouldReturnCorrectTodo()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); // Ensure starting from a known state
            Todo1 todo = service.CreateTodo("Test todo");

            // Act
            Todo1 foundTodo = service.FindById(todo.Id);

            // Assert
            Assert.NotNull(foundTodo);
            Assert.Equal(todo.Id, foundTodo.Id);
        }
        [Fact]
        public void Clear_ShouldRemoveAllTodoItems()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); // Ensure starting from a known state
            service.CreateTodo("Test todo");

            // Act
            service.clear();
            int sizeAfterClear = service.Size();

            // Assert
            Assert.Equal(0, sizeAfterClear);
        }
        [Fact]
        public void FindByDoneStatus_shouldReturnMatchingTodo()
        {
            //Arrange
            TodoService service = new TodoService();
            service.clear();
            service.CreateTodo("Test todo 1", done: true);
            service.CreateTodo("Test todo 2", done: false);
            service.CreateTodo("Test todo 3", done: true);
            // Act
            Todo1[] doneTodos = service.FindByDoneStatus(true);
            Todo1[] notDoneTodos = service.FindByDoneStatus(false);

            // Assert
            Assert.Equal(2, doneTodos.Length);
            Assert.All(doneTodos, t => Assert.True(t.Done));
            Assert.Single(notDoneTodos);
            Assert.All(notDoneTodos, t => Assert.False(t.Done));


        }
        [Fact]
        public void FindByAssignee_ShouldReturnMatchingTodosByPersonId()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); // Ensure starting from a known state
            Person assignee = new Person(Personsequencer.NextPersonId(), "John", "Doe");
            service.CreateTodo("Test todo 1", assignee: assignee);
            service.CreateTodo("Test todo 2", assignee: null);

            // Act
            Todo1[] assignedTodos = service.FindByAssignee(assignee.Id);

            // Assert
            Assert.Single(assignedTodos);
            Assert.All(assignedTodos, t => Assert.Equal(assignee.Id, t.Assignee.Id));
        }
        [Fact]
        public void FindByAssignee_ShouldReturnMatchingTodosByPerson()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); 
            Person assignee = new Person(Personsequencer.NextPersonId(), "John", "Doe");
            service.CreateTodo("Test todo 1", assignee: assignee);
            service.CreateTodo("Test todo 2", assignee: null);

            // Act
            Todo1[] assignedTodos = service.FindByAssignee(assignee);

            // Assert
            Assert.Single(assignedTodos);
            Assert.All(assignedTodos, t => Assert.Equal(assignee, t.Assignee));
        }
        [Fact]
        public void FindUnassignedTodoItems_ShouldReturnTodosWithNoAssignee()
        {
            //Arrange
           TodoService service = new TodoService();
            service.clear();
            service.CreateTodo("Test todo 1", assignee: new Person(Personsequencer.NextPersonId(), "prisha", "dhruv"));
            service.CreateTodo("Test todo 2", assignee: null);

            //Act
           Todo1[] unassignedTodos = service.FindUnAssignedTodoItem();

           // Assert
            Assert.Single(unassignedTodos);
            Assert.All(unassignedTodos, t => Assert.Null(t.Assignee));
        }
        [Fact]
        public void Remove_ShouldReturnTrueAndRemoveTodo_WhenTodoExists()
        {
            // Arrange
            TodoService service = new TodoService();
            service.clear(); // Ensure starting from a known state
            Todo1 todo = service.CreateTodo("Test todo");

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
            TodoService service = new TodoService();
            service.clear(); 

            // Act
            bool result = service.Remove(999); // ID that doesn't exist

            // Assert
            Assert.False(result);
        }











    }
}
