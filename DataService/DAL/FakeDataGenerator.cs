using System;
using POTD.DataService.DAL.Repositories;
using POTD.DataService.Models;

namespace POTD.DataService.DAL
{
    internal static class FakeDataGenerator
    {
        public static DayRepository GenerateDayRepository()
        {
            DayRepository repo = new DayRepository();

            repo.Add(new DayModel(0, DateTime.Today.AddDays(-1)));

            repo.Add(new DayModel(2, DateTime.Today.AddDays(1)));

            repo.Add(new DayModel(1, DateTime.Today));

            return repo;
        }

        public static ProjectRepository GenerateProjectRepository()
        {
            ProjectRepository repo = new ProjectRepository();

            repo.Add(new ProjectModel(0)
            {
                Name = "Test Project"
            });

            return repo;
        }

        public static TaskRepository GenerateTaskRepository()
        {
            TaskRepository repo = new TaskRepository();

            repo.Add(new TaskModel(0)
            {
                ProjectId = 0,
                DayId = 1,
            });

            return repo;
        }
    }
}