using clean.core.Entities;
using clean.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.data.Repositories
{

    public class Repository<T, E> : IRepository<T, E> where T : class
    {

        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _dbSet = context.Set<T>();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(E id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(E id)
        {
            return _dbSet.Find(id);
        }
        public T Put(T entity)
        {
            _dbSet.Update(entity);
            return entity;

        }
    }
}

