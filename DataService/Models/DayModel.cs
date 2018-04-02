using System;

namespace POTD.DataService.Models
{
    public class DayModel : ModelBase
    {
        public DayModel(int id) : base(id)
        {
        }

        public DateTime Date { get; set; }
    }
}