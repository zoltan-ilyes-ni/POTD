using POTD.DataService.Models;

namespace POTD.DataService.DAL.Repositories
{
    internal class TaskRepository : RepositoryBase<TaskModel>
    {
        public override TaskModel Add(TaskModel entity)
        {
            TaskModel newEntity = new TaskModel(GetNextId())
            {
                DayId = entity.DayId,
                MinutesSpent = entity.MinutesSpent,
                Name = entity.Name,
                Notes = entity.Notes,
                Priority = entity.Priority,
                ProjectId = entity.ProjectId,
                Rank = entity.Rank,
                Status = entity.Status,
            };
            All.Add(newEntity);
            return newEntity;
        }
    }
}