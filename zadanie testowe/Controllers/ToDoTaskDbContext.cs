using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;


namespace zadanie_testowe.Controllers
{
    public class ToDoTaskDbContext : DbContext
    {
        private string _connectionString = "server=127.0.0.1;port=3306;user=root;password=root;database=Local";

        public DbSet<ToDoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set tittle as required value.
            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Tittle)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

        }
    }
}
