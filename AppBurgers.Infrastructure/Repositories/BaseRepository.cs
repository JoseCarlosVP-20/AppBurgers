using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AppBurgers.Core.Interfaces;
using AppBurgers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppBurgers.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppBurgerContext _context;
        private readonly DbSet<TEntity> _dbset;

        public BaseRepository(AppBurgerContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbset.Attach(entityToDelete);
            }
            _dbset.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            TEntity entotytoDelete = GetById(id);
            Delete(entotytoDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbset;
            if(query != null){
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

        }

        public TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            _dbset.Add(entityToInsert);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbset.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}