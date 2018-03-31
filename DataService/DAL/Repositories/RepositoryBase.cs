using System.Collections.Generic;
using System.Linq;
using POTD.DataService.Models;

namespace POTD.DataService.DAL.Repositories
{
    internal abstract class RepositoryBase<TEntity>
        where TEntity : ModelBase
    {
        public TEntity GetById(int id)
        {
            return All.FirstOrDefault(t => t.Id == id);
        }

        public abstract TEntity Add(TEntity entity);

        public void Remove(TEntity entity)
        {
            All.Remove(entity);
        }

        public List<TEntity> All { get; private set; }

        public RepositoryBase()
        {
            All = new List<TEntity>();
        }

        protected int GetNextId()
        {
            int nextId = 0;
            foreach (TEntity entity in All)
            {
                if (entity.Id > nextId)
                {
                    nextId = entity.Id;
                }
            }
            return nextId;
        }
    }
}