using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.GenericRepo
{
    public interface IRepo
    {
        Task<List<T>> SelectAsync<T>() where T : class;
        Task<T> SelectById<T>(int id) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task Create<T>(T entity) where T : class;
    }
}
