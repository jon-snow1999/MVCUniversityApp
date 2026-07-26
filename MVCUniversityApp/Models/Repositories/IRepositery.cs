using Microsoft.EntityFrameworkCore;

namespace MVCUniversityApp.Models.Repositories
{
    public interface IRepositery<T>
    {
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public T? getById(int id);
        public List<T> getAll();
        public void SaveDB();
    }
}
