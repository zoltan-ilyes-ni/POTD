using POTD.DataService.Models;

namespace POTD.DataService.DAL.Repositories
{
    internal class ProjectRepository : RepositoryBase<ProjectModel>
    {
        public override ProjectModel Add(ProjectModel entity)
        {
            ProjectModel newEntity = new ProjectModel(GetNextId())
            {
                Name = entity.Name,
                Color = entity.Color,
            };
            All.Add(newEntity);
            return newEntity;
        }
    }
}