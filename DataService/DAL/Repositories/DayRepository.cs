using System;
using POTD.DataService.Models;

namespace POTD.DataService.DAL.Repositories
{
    internal class DayRepository : RepositoryBase<DayModel>
    {
        public override DayModel Add(DayModel entity)
        {
            DayModel newEntity = new DayModel(GetNextId())
            {
                Date = entity.Date,
            };
            All.Add(newEntity);
            return newEntity;
        }

        public DayModel Add(DateTime date)
        {
            DayModel newEntity = new DayModel(GetNextId())
            {
                Date = date,
            };
            All.Add(newEntity);
            return newEntity;
        }
    }
}