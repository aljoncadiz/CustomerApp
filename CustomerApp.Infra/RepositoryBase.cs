using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infra
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : EntityBase
    {

        private List<T> _data;

        protected List<T> Data
        {
            get { return _data; }
            set
            {
                this._data = value;
            }
        }

        public RepositoryBase(List<T> data)
        {
            _data = data;
        }

        public virtual T Create(T entity)
        {
            Data.Add(entity);
            T newlyCreatedEntity = FindById(entity.ID);
            return newlyCreatedEntity;
        }

        public void Delete(int key)
        {
            T entityToDelete = FindById(key);
            Data.Remove(entityToDelete);
        }

        public IEnumerable<T> FindAll()
        {
            IEnumerable<T> query = from e in Data
                               orderby e.ID
                               select e;

            return query;
        }

        public T FindById(int key)
        {
            return Data.Find(x => x.ID == key);
        }

        public T Update(int key, T entity)
        {
            T updatedEntity = Data.Where(x => x.ID == key).Select(e => entity).FirstOrDefault();
            return updatedEntity;
        }
    }
}
