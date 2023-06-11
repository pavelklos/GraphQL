using GraphQLWithEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithEFCore.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student { Id = 1, Name = "Shakib", Roll = "1001" },
                    new Student { Id = 2, Name = "Rahat", Roll = "1002" },
                    new Student { Id = 3, Name = "Rohit", Roll = "1003" },
                    new Student { Id = 4, Name = "Musfiq", Roll = "1004" },
                    new Student { Id = 5, Name = "Ratan", Roll = "1005" }
                );
        }
    }
}
