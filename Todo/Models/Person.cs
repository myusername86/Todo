namespace Todo.Models
{
    public class Person
    {
        private readonly int id;

        private string firstName;

        private string lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int Id
        {
            get { return id; }
        }
        public string FirstName
        {
            get { return firstName; }

            set
            {
                if (firstName != value)
                {
                    throw new InvalidOperationException("First name cannot be empty");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }

            set
            {
                if (lastName != value)
                {
                    throw new InvalidOperationException("Last name cannot be empty");
                }
                lastName = value;
            }
        }
        
       

            
           
         

    }
}
