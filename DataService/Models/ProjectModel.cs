namespace PlanYourDay.DataService.Models
{
    public class ProjectModel : ModelBase
    {
        public ProjectModel(int id) : base(id)
        {
        }

        public string Color { get; set; }

        public string Name { get; set; }
    }
}