namespace PlanYourDay.Common.Models
{
    public class Task
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public int ProjectId { get; set; }

        public int Rank { get; set; }

        public TaskStatus Status { get; set; }

        public int Time { get; set; }
    }
}