using System.Collections.Generic;

namespace PlanYourDay.Common.Models
{
    public class Backlog
    {
        public IEnumerable<Task> Tasks { get; private set; }
    }
}