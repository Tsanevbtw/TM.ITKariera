using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NESHTO.Models;

namespace NESHTO.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NESHTO.Models.TaskList> TaskList { get; set; } = default!;
        public DbSet<NESHTO.Models.ToDoTask> ToDoTask { get; set; } = default!;

    }
}
