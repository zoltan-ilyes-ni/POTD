using System.Collections.Generic;
using PlanYourDay.Common.Interfaces;

namespace PlanYourDay.FileDataService
{
    public class RepositoryBase<T> : IDataRepository<T>
    {
        public RepositoryBase()
        {
            All = new List<T>();
        }

        private List<T> All { get; set; }

        public T Create(T entity)
        {
            All.Add(entity);
            return entity;
        }

        public IEnumerable<T> ReadAll()
        {
            return All as IEnumerable<T>;
        }

        public IEnumerable<T> Remove(T entity)
        {
            All.Remove(entity);
            return ReadAll();
        }
    }
}
