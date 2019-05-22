using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibMgmtSys.IDAL
{
    public interface IDataWriter<T> where T : class
    {
        int Insert(T entity);

        IEnumerable<T> Insert(IEnumerable<T> entities);

        int Delete(Expression<Func<T, bool>> whereExpression);

        int Update(T entity);
    }
}
