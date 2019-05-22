﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibMgmtSys.IDAL
{
    public interface IDataWriter<T> where T : class
    {
        dynamic Insert(T entity);

        void Insert(IEnumerable<T> entities);

        int Delete(Expression<Func<T, bool>> whereExpression);

        int Update(object entity, Expression<Func<T, bool>> whereExpression);
    }
}
