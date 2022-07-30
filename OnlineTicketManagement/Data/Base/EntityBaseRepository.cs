using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineTicketManagement.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly TicketDbContext _db;
        public EntityBaseRepository(TicketDbContext db)
        {
            _db = db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _db.Set<T>().FirstOrDefault(x => x.Id == id);
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            var result = _db.Set<T>().ToList();
            return result;
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _db.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
            return query.ToList();
        }

        public T GetById(int id)
        {
            var result = _db.Set<T>().FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void Update(int id, T entity)
        {
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
