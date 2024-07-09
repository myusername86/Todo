using System;
using Todo.Models;

namespace Todo.Models
{
    public class Todo1
    {
        private readonly int id;
        private string description;
        private bool done;
        private Person assignee;

        public Todo1(int id, string description)
        {
            this.id = id;
            this.description = description;
            done = false;
        }
        public int Id
        {

        get { return id; } 
        }
        public string Description
        {

        get { return description; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description cannot be null");
                }

            description = value; 
            }
        }

        public bool Done
        {

        get 
            { 
                return done; 
            }
            set
            {
                done = value;
            }
        }
        public Person Assignee
        {

        get { return assignee; }
        set{ assignee = value; }
        }
    }
        



    }

