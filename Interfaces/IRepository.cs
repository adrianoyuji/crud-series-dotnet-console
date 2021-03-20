using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnsById(int Id);
        void Insert(T entity);
        void Delete(int Id);
        void Update(int Id, T entity);
        int NextId();
    }
}