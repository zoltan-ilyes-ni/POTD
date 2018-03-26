using System;
using PTD.Infrastructure.Interfaces;
using PTD.Infrastructure.Models;

namespace PTD.DataService
{
    public class DataService
    {
        public string SourcePath { get; private set; }
        public IDataRepository<BacklogItem> BacklogRepository { get; private set; }
        public IDataRepository<Day> DayRepository { get; private set; }
        public IDataRepository<Project> ProjectRepository { get; private set; }
        public IDataRepository<Task> TaskRepository { get; private set; }

        DataService()
        {
            BacklogRepository = new RepositoryBase<BacklogItem>();
            DayRepository = new RepositoryBase<Day>();
            ProjectRepository = new RepositoryBase<Project>();
            TaskRepository = new RepositoryBase<Task>();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SaveAs(string sourcePath)
        {
            throw new NotImplementedException();
            //SourcePath = sourcePath;
        }

        public void Load(string sourcePath)
        {
            throw new NotImplementedException();
            //SourcePath = sourcePath;
        }
    }
}