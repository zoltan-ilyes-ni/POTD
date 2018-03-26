using System.Collections.Generic;

namespace PTD.Infrastructure.Interfaces
{
    public interface IDataRepository<TEntity>
        where TEntity : IDataModel
    {
        TEntity GetById(int id);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        List<TEntity> All { get; }
    }
}