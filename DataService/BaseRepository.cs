using System.Collections.Generic;
using System.Linq;
using POTD.Infrastructure.Interfaces;

namespace POTD.DataService
{
    public class RepositoryBase<TEntity> : IDataRepository<TEntity>
        where TEntity : IDataModel
    {
        public TEntity GetById(int id)
        {
            return All.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TEntity entity)
        {
            All.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            All.Remove(entity);
        }

        public List<TEntity> All { get; private set; }
    }
}