using System;
using Xunit;
using Todo.Data;
using Todo.Models;
namespace TestPeopleservice
{
    public class PeopleServiceTest
    {
        [Fact]

        public void ReturnZero_WhenNoPeopleAdded()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.clear(); // Ensure starting from a known state

            // Act
            int size = service.Size();

            // Assert
            Assert.Equal(0, size);
        }
        [Fact]
        public void FindAll_ShouldReturnEmptyArray_WhenNoPeopleAdded()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.clear(); // Ensure starting from a known state

            // Act
            Person[] allPeople = service.FindAll();

            // Assert
            Assert.Empty(allPeople);
        }
        [Fact]
        public void CreatePerson_ShouldAddPersonToTheArray()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.clear(); // Ensure starting from a known state

            // Act
            Person person = service.CreatePerson("John", "Doe");

            // Assert
            Assert.NotNull(person);
            Assert.Equal(1, service.Size());
            Assert.Contains(person, service.FindAll());
        }
        [Fact]
        public void FindById_ShouldReturnCorrectPerson()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.clear(); // Ensure starting from a known state
            Person person = service.CreatePerson("John", "Doe");

            // Act
            Person foundPerson = service.FindById(person.Id);

            // Assert
            Assert.NotNull(foundPerson);
            Assert.Equal(person.Id, foundPerson.Id);
        }
        [Fact]
        public void Clear_ShouldRemoveAllPeople()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.clear(); // Ensure starting from a known state
            service.CreatePerson("John", "Doe");

            // Act
            service.clear();
            int sizeAfterClear = service.Size();

            // Assert
            Assert.Equal(0, sizeAfterClear);
        }






    }
}
