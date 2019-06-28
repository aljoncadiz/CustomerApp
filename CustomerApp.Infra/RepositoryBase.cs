using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<T> Create(T entity)
        {
            Data.Add(entity);
            T newlyCreatedEntity = await FindById(entity.ID);
            return newlyCreatedEntity;
        }

        public async Task Delete(int key)
        {
            T entityToDelete = await FindById(key);
            Data.Remove(entityToDelete);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await Task.Run(() => Data.OrderBy(x => x.ID));
        }

        public async Task<T> FindById(int key)
        {
            return await Task.Run(() => Data.Where(x => x.ID == key).FirstOrDefault());
        }

        public async Task<T> Update(int key, T entity)
        {
            return await Task.Run(() => Data.Where(x => x.ID == key).Select(e => entity).FirstOrDefault());
        }
    }
}
