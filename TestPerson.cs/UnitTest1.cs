using System;
using Todo.Models;
using Xunit;

namespace TestPerson.cs
{
    public class UnitTest1
    {
        [Fact]
        public void Constructor_initiate()
        {
            //Arrange
            int expectedid = 1;
            string expected_firstName = "yuva";
            string expected_lastName = "Rani";

            //Act
            Person person = new Person(expectedid, expected_firstName, expected_lastName);

            //Assert
            Assert.Equal(expectedid, person.Id);
            Assert.Equal(expected_firstName, person.FirstName);
            Assert.Equal(expected_lastName, person.LastName);


        }
        
    }
}

        
    


