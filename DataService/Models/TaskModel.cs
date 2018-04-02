namespace POTD.DataService.Models
{
    public class TaskModel : ModelBase
    {
        public TaskModel(int id) : base(id)
        {
        }

        public int DayId { get; set; }

        public bool Done { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }

        public int Rank { get; set; }

        public int Time { get; set; }
    }
}