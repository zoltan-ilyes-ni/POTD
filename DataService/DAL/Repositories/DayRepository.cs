using System;
using System.Linq;
using PlanYourDay.DataService.Models;

namespace PlanYourDay.DataService.DAL.Repositories
{
    internal class DayRepository : RepositoryBase<DayModel>
    {
        public DayModel GetByDate(DateTime date)
        {
            return All.FirstOrDefault(d => d.Date == date);
        }
    }
}