using Microsoft.EntityFrameworkCore;
using MyTodoAppBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyCrudApp.Models
{
    public class TodoContext : IdentityDbContext<ApplicationUser>
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}