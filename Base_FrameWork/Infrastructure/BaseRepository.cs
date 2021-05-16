using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Base_FrameWork
{
    public class BaseRepository<TKey,T> : IBaseRepository<TKey,T> where T : DomainBase<TKey>
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }
    }
}
