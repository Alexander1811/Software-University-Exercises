﻿namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<EmployeeTask> EmployeesTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>(e =>
               e.HasKey(e => new { e.EmployeeId, e.TaskId })
            );
        }
    }
}