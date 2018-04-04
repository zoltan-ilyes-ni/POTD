using Newtonsoft.Json;
using PlanYourDay.DataService.DAL.Repositories;

namespace PlanYourDay.DataService.DAL
{
    internal class UnitOfWork
    {
        public UnitOfWork()
        {
            ProjectRepository = new ProjectRepository();
            TaskRepository = new TaskRepository();
            DayRepository = new DayRepository();
        }

        public UnitOfWork(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new System.ArgumentException("File Path is Empty!", nameof(filePath));
            }
            UnitOfWork tmp = JsonConvert.DeserializeObject<UnitOfWork>(System.IO.File.ReadAllText(filePath));
            ProjectRepository = tmp.ProjectRepository;
            TaskRepository = tmp.TaskRepository;
            DayRepository = tmp.DayRepository;
        }

        public DayRepository DayRepository { get; private set; }

        public ProjectRepository ProjectRepository { get; private set; }

        public TaskRepository TaskRepository { get; private set; }

        public void Save(string filePath)
        {
            string serializedData = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(filePath, serializedData);
        }
    }
}