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
        public DbSet<NESHTO.Models.Model> Model { get; set; } = default!;
        public DbSet<NESHTO.Models.SingleTask> SingleTask { get; set; } = default!;
        public DbSet<NESHTO.Models.RepeatingTask> RepeatingTask { get; set; } = default!;
    }
}
