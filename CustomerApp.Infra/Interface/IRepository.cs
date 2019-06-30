using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infra.Interface
{
    public interface IRepository<T> where T: IEntityBase
    {
        Task<T> Create(T entity);

        Task<T> Update(int key, T entity);

        Task Delete(int key);

        Task<T> FindById(int key);

        Task<IEnumerable<T>> FindAll();
    }
}
