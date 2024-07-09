using System;
using System.Linq;
using Todo.Models;
namespace Todo.Data
{
    public class PeopleService
    {
        private static Person[] people = new Person[0];
        //method to return the size of the people array
        public int Size()

            { 
            return people.Length;
        }

        //method to return all Person object
        public Person[] FindAll()
        {

        return people; 
        }
    //method to find the person by id
    public Person FindById(int PersonId)
        {
            return people.FirstOrDefault(p=>p.Id == PersonId);
        }

        //methos to create a new person add it to the array,and return the created object

        public Person CreatePerson(string firstName, string lastName)
        {
            int newId = Personsequencer.NextPersonId();
            Person newPerson=new Person(newId, firstName, lastName);
            Array.Resize(ref people,people.Length +1);
            people[people.Length-1] = newPerson;

            return newPerson;

        }

        public void clear()
        {
            people = new Person[0];
        }
    }
}
