using System;
using System.Linq;
using POTD.DataService.Models;

namespace POTD.DataService.DAL.Repositories
{
    internal class DayRepository : RepositoryBase<DayModel>
    {
        public DayModel GetByDate(DateTime date)
        {
            return All.FirstOrDefault(d => d.Date == date);
        }
    }
}