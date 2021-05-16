using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Base_FrameWork
{
    public interface IBaseRepository<in TKey , T> where T : DomainBase<TKey>
    {
        List<T> GetAll();
        void Create(T entity);
        T GetBy(TKey id);
        bool Exist(Expression<Func<T, bool>> expression);
    }
}
