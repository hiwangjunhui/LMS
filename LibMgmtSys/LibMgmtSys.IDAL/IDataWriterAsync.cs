using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibMgmtSys.IDAL
{
    public interface IDataWriterAsync<T> where T : class
    {
        Task<dynamic> InsertAsync(T entity);

        Task InsertAsync(IEnumerable<T> entities);

        Task<int> DeleteAsync(Expression<Func<T, bool>> whereExpression);

        Task<int> UpdateAsync(object entity, Expression<Func<T, bool>> whereExpression);
    }
}
