namespace PTD.Infrastructure.Models
{
    public class Task : DataModelBase
    {
        public int BacklogItemId { get; private set; }

        public int DayId { get; set; }

        public int Rank { get; set; }

        public string Status { get; set; }

        public int MinutesSpent { get; set; }
    }
}