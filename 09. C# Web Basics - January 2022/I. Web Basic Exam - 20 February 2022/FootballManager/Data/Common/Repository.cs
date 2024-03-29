﻿namespace FootballManager.Data.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(FootballManagerDbContext context)
        {
            this.dbContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public void Remove<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }
    }
}
