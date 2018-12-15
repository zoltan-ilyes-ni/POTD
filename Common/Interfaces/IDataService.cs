using PlanYourDay.Common.Models;

namespace PlanYourDay.Common.Interfaces
{
    public interface IDataService
    {
        string ConnectionString { get; }

        IDataRepository<Day> Days { get; }

        IDataRepository<Project> Projects { get; }

        IDataRepository<RecurringTask> RecurringTasks { get; }

        IDataRepository<Task> Tasks { get; }

        void Close();

        void Open(string connectionString);

        void Save();

        void SaveAs(string connectionString);
    }
}