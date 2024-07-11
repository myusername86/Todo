using System.Collections.Generic;
using System;
using System.Linq;
using Todo.Models;
using Microsoft.EntityFrameworkCore;
using Todo.DATA;
namespace Todo.Data
{
    public class Todoservice
    {                            
       
        private static Todo1[] todoitems = new Todo1[0];
        //method to return the size of the people array
        public int Size()

        {
            return todoitems.Length;
        }

        //method to return all Person object
        public Todo1[] FindAll()
        {

            return todoitems;
        }
        //method to find the person by id
        public Todo1 FindById(int ItemsId)
        {
            return todoitems.FirstOrDefault(p => p.Id == ItemsId);
        }

        //methos to create a new person add it to the array,and return the created object

        public Todo1 CreateItem(string newdescription)
        {
            int newId = Personsequencer.NextPersonId();
            Todo1 newItem = new Todo1(newId, newdescription);
            Array.Resize(ref todoitems, todoitems.Length + 1);
            todoitems[todoitems.Length - 1] = newItem;

            return newItem;

        }

        public void clear()
        {
            todoitems = new Todo1[0];
        }

        // Method to find Todo items by their done status
        public Todo1[] FindByDoneStatus(bool doneStatus)
        {
            return todoitems.Where(t => t.Done == doneStatus).ToArray();
        }
        // Method to find Todo items by their assignee's person ID
        public Todo1[] FindByAssignee(int personId)
        {
            return todoitems.Where(t => t.Assignee != null && t.Assignee.Id == personId).ToArray();
        }
        // Method to find Todo items by their assignee
        public Todo1[] FindByAssignee(Person assignee)
        {
            return todoitems.Where(t => t.Assignee == assignee).ToArray();
        }
        // Method to find Todo items that are unassigned
        public Todo1[] FindUnassignedTodoItems()
        {
            return todoitems.Where(t => t.Assignee == null).ToArray();
        }

        //Method to item by id
        public bool Remove(int itemId)
        {
            int index = Array.FindIndex(todoitems, p => p.Id == itemId);
            if (index < 0) return false;
            var tempList = todoitems.ToList();
            tempList.RemoveAt(index);
            todoitems = tempList.ToArray();
            return true;
        }
    }
}
