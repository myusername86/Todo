using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.DATA
{
    public class TodoContext : DbContext
    {
        //creating constructor
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Todo1> Todo1 { get; set; }
    }
}