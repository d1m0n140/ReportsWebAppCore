using Microsoft.EntityFrameworkCore;
using ReportsWebApp.Models;

namespace ReportsWebApp.Data
{
    public class TasksDbContext : DbContext
    {
        private readonly string connectionString;

        public TasksDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CKMBB11\\SQLEXPRESS;Initial Catalog=TasksDB;Persist Security Info=True;User ID=sa;Password=Supervisor2");
        }
    }
}
