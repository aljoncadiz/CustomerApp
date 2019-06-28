using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infra.Interface
{
    public interface IRepository<T> where T: EntityBase
    {
        T Create(T entity);

        T Update(int key, T entity);

        void Delete(int key);

        T FindById(int key);

        IEnumerable<T> FindAll();
    }
}
