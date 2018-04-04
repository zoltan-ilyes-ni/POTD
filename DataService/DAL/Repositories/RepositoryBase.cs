using System;
using System.Collections.Generic;
using System.Linq;
using PlanYourDay.DataService.Models;

namespace PlanYourDay.DataService.DAL.Repositories
{
    internal abstract class RepositoryBase<TEntity>
        where TEntity : ModelBase
    {
        public RepositoryBase()
        {
            All = new List<TEntity>();
        }

        public List<TEntity> All { get; private set; }

        public TEntity Add(TEntity entity)
        {
            foreach (TEntity e in All)
            {
                if (e.Id == entity.Id)
                {
                    throw new Exception("ID already exists!");
                }
            }
            All.Add(entity);

            return entity;
        }

        public TEntity GetById(int id)
        {
            return All.FirstOrDefault(t => t.Id == id);
        }

        public int GetNextId()
        {
            int nextId = 0;
            foreach (TEntity entity in All)
            {
                if (entity.Id > nextId)
                {
                    nextId = entity.Id;
                }
            }
            return ++nextId;
        }

        public void Remove(TEntity entity)
        {
            All.Remove(entity);
        }
    }
}