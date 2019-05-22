using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibMgmtSys.Service
{
    public class Service<T> : IService.IService<T> where T : class
    {
        private IDAL.IDAL<T> _dal;
        public Service(IDAL.IDAL<T> dal)
        {
            _dal = dal;
        }

        public int Insert(T entity)
        {
            return _dal.Insert(entity);
        }

        public T QuerySingle(Expression<Func<T, bool>> whereExpression)
        {
            return _dal.QuerySingle(whereExpression);
        }

        public int Remove(Expression<Func<T, bool>> whereExpression)
        {
            return _dal.Delete(whereExpression);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> whereExpression)
        {
            return _dal.Select(whereExpression);
        }

        public int Update(T entity)
        {
            return _dal.Update(entity);
        }
    }
}
