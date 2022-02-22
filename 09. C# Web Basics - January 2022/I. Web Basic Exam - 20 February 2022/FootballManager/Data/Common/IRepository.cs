namespace FootballManager.Data.Common
{
    using System.Linq;

    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        void Remove<T>(T entity) where T : class;

        int SaveChanges();
    }
}
