namespace POTD.DataService.Models
{
    public class ProjectModel : ModelBase
    {
        public ProjectModel(int id) : base(id)
        {
        }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}