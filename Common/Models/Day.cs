using System;
using System.Collections.Generic;

namespace PlanYourDay.Common.Models
{
    public class Day
    {
        public DateTime Date { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}