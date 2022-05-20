using Microsoft.EntityFrameworkCore;
using ToDoWebApp032022.Data.Entities;

namespace ToDoWebApp032022.Data
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; } = default!;
        public DbSet<ToDoList> ToDoLists { get; set; } = default!;

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
    }
}
