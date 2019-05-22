using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibMgmtSys.IService
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> Select(Expression<Func<T, bool>> whereExpression);

        T QuerySingle(Expression<Func<T, bool>> whereExpression);

        int Insert(T entity);

        int Remove(Expression<Func<T, bool>> whereExpression);

        int Update(T entity);
    }
}
