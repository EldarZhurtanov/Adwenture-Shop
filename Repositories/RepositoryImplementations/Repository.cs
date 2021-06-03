﻿using Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryImplementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        T IRepository<T>.Get(int id)
        {
            return _dbSet.Find(id);
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(T model)
        {
            _dbSet.Remove(model);
        }
        public IQueryable<T> GetList()
        {
            return _dbSet as IQueryable<T>;
        }
        public IQueryable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}