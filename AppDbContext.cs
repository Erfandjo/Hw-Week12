using Hw_Week12.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hw_Week12
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Configuration.Configuration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Entities.User> Users { get; set; }
    }
}
