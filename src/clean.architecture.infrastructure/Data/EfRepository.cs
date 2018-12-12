using clean.architecture.core.Interfaces;
using clean.architecture.core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace clean.architecture.infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> List()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.SaveChanges();
        }
    }
}
