namespace PTD.Infrastructure.Models
{
    public class BacklogItem : DataModelBase
    {
        public int ProjectId { get; set; }
        private string Name { get; set; }
        private string Notes { get; set; }
        private int TimeEstimate { get; set; }
        public int Priority { get; set; }
    }
}