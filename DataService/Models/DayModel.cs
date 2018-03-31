using System;

namespace POTD.DataService.Models
{
    public class DayModel : ModelBase
    {
        public DayModel(int id) : base(id)
        {
        }

        public DayModel(int id, DateTime date) : this(id)
        {
            Date = date.Date;
        }

        public DateTime Date { get; set; }
    }
}