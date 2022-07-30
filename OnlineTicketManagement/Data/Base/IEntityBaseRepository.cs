using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineTicketManagement.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
    }
}
