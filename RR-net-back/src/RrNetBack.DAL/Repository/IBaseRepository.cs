using System.Threading.Tasks;

namespace RrNetBack.DAL.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}
