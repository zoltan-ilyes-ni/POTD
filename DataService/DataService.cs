using System;
using POTD.Infrastructure.Interfaces;
using POTD.Infrastructure.Models;

namespace POTD.DataService
{
    public class DataService
    {
        public string SourcePath { get; private set; }
        public IDataRepository<BacklogItemDataModel> BacklogRepository { get; private set; }
        public IDataRepository<DayDataModel> DayRepository { get; private set; }
        public IDataRepository<ProjectDataModel> ProjectRepository { get; private set; }
        public IDataRepository<TaskDataModel> TaskRepository { get; private set; }

        private DataService()
        {
            BacklogRepository = new RepositoryBase<BacklogItemDataModel>();
            DayRepository = new RepositoryBase<DayDataModel>();
            ProjectRepository = new RepositoryBase<ProjectDataModel>();
            TaskRepository = new RepositoryBase<TaskDataModel>();
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