using GlobusRemote.Data.Const;
using GlobusRemote.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GlobusRemote.Data.Repositories
{
    public class BaseRepository<Entity>
        where Entity : BaseEntity
    {
        protected MainDbContext _mainDbContext;
        protected DbSet<Entity> _dbSet;

        public BaseRepository(MainDbContext dbContext)
        {
            _mainDbContext = dbContext;
            _dbSet = _mainDbContext.Set<Entity>();
        }

        //public Type GetEntity()
        //{
        //    return typeof(Entity);
        //}

        //public Entity Get(long id)
        //{
        //    return _dbSet.SingleOrDefault(x => x.Id == id);
        //}

        public List<Entity> GetAll()
        {
            return _dbSet.ToList();
        }

        protected virtual IQueryable<Entity> ApplyFiltering(IQueryable<Entity> query, string search)
        {
            return query;
        }

        private IQueryable<Entity> ApplySorting(IQueryable<Entity> query, string sortField, SortDirections sortDir)
        {
            if (sortDir == SortDirections.Ascending)
            {
                query = query
                    .OrderBy(sortField);
            }
            else
            {
                query = query
                    .OrderBy(sortField + " descending");
            }
            return query;
        }

        public List<Entity> GetWithParams(int page, int perPage, string sortField, SortDirections sortDir, string search)
        {
            IQueryable<Entity> query = _dbSet;

            if (!String.IsNullOrEmpty(search))
            {
                query = ApplyFiltering(query, search);
            }

            if (!String.IsNullOrEmpty(sortField))
            {
                query = ApplySorting(query, sortField, sortDir);
            }

            query = query
                .Skip((page - 1) * perPage)
                .Take(perPage);

            return query.ToList();
        }

        public int Count(string sortField, SortDirections sortDir, string search)
        {
            IQueryable<Entity> query = _dbSet;

            if (!String.IsNullOrEmpty(search))
            {
                query = ApplyFiltering(query, search);
            }

            if (!String.IsNullOrEmpty(sortField))
            {
                query = ApplySorting(query, sortField, sortDir);
            }

            return query.Count();
        }        

        public void Save(Entity entity)
        {
            //if (model.Id > 0)
            //{
            //    _mazeDbContext.Update(model);
            //}
            //else
            //{
            //    _dbSet.Add(model);
            //}

            _mainDbContext.SaveChanges();
        }

        public void Remove(Entity entity)
        {
            _dbSet.Remove(entity);
            _mainDbContext.SaveChanges();
        }
    }
}