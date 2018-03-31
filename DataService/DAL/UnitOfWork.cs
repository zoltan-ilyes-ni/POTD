using POTD.DataService.DAL.Repositories;

namespace POTD.DataService.DAL
{
    internal class UnitOfWork
    {
        public UnitOfWork()
        {
            ProjectRepository = FakeDataGenerator.GenerateProjectRepository();
            TaskRepository = FakeDataGenerator.GenerateTaskRepository();
            DayRepository = FakeDataGenerator.GenerateDayRepository();
        }

        public UnitOfWork(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new System.ArgumentException("File Path is Empty!", nameof(filePath));
            }
        }

        public DayRepository DayRepository { get; private set; }

        public ProjectRepository ProjectRepository { get; private set; }

        public TaskRepository TaskRepository { get; private set; }

        public void Save(string filePath)
        {
        }
    }
}