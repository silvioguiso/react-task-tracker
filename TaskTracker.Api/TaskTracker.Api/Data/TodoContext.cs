using Microsoft.EntityFrameworkCore;
using System;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<ToDo> Todos { get; set; }

        public string DbPath { get; }

        public TodoContext()
        {
            DbPath = System.IO.Path.Join(Environment.CurrentDirectory, "SqlLite", "tasktracker.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.Entity<ToDo>().ToTable("Tasks");
    }
}
