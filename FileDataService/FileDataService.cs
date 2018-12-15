using Newtonsoft.Json;
using PlanYourDay.Common.Interfaces;
using PlanYourDay.Common.Models;
using System;

namespace PlanYourDay.FileDataService
{
    public class FileDataService : IDataService
    {
        [JsonIgnore]
        public string ConnectionString { get; private set; }

        [JsonProperty]
        public IDataRepository<Day> Days { get; private set; }

        [JsonProperty]
        public IDataRepository<Project> Projects { get; private set; }

        [JsonProperty]
        public IDataRepository<RecurringTask> RecurringTasks { get; private set; }

        [JsonProperty]
        public IDataRepository<Task> Tasks { get; private set; }

        public void Close()
        {
        }

        public void Open(string connectionString)
        {
            string fileContent;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("File Path is Empty!", nameof(connectionString));
            }
            try
            {
                fileContent = System.IO.File.ReadAllText(connectionString);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can't read file! Details:  " + ex.Message, ex);
            }

            try
            {
                FileDataService tmp = JsonConvert.DeserializeObject<FileDataService>(fileContent);
                this.Days = tmp.Days;
                this.Projects = tmp.Projects;
                this.Backlog = tmp.Backlog;
                this.RecurringTasks = tmp.RecurringTasks;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can't deserialize file content! Details: " + ex.Message, ex);
            }
            ConnectionString = connectionString;
        }

        public void Save() => SaveAs(ConnectionString);

        public void SaveAs(string connectionString)
        {
            string serializedData;
            try
            {
                serializedData = JsonConvert.SerializeObject(this);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can't serialize data! Details: " + ex.Message, ex);
            }

            try
            {
                System.IO.File.WriteAllText(connectionString, serializedData);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can't write file! Details: " + ex.Message, ex);
            }
        }
    }
}