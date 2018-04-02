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

            repo.Add(
                new DayModel(0)
                {
                    Date = DateTime.Today.AddDays(-1)
                });

            repo.Add(
                new DayModel(2)
                {
                    Date = DateTime.Today.AddDays(1)
                });

            repo.Add(
                new DayModel(1)
                {
                    Date = DateTime.Today
                });

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
                Name = "Fake task 1",
                ProjectId = 0,
                DayId = 1,
            });

            repo.Add(new TaskModel(1)
            {
                Name = "Fake task 2",
                ProjectId = 0,
                DayId = 1,
            });

            repo.Add(new TaskModel(2)
            {
                Name = "Fake task 3",
                ProjectId = 0,
                DayId = 0,
            });

            return repo;
        }
    }
}