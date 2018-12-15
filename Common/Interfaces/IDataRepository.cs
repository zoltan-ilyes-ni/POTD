using System.Collections.Generic;

namespace PlanYourDay.Common.Interfaces
{
    public interface IDataRepository<T>
    {
        T Create(T entity);
        IEnumerable<T> Remove(T entity);
        IEnumerable<T> ReadAll();
    }
}
