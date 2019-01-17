using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ToDoListApi.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                optionsBuilder.UseSqlServer("Server=DESKTOP-2JCS6AV\\SQLEXPRESS;Database=ToDoList;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }   
    }
}
