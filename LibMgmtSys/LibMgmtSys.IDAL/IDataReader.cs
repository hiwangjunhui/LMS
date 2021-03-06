﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibMgmtSys.IDAL
{
    public interface IDataReader<T> where T : class
    {
        IEnumerable<T> Select(Expression<Func<T, bool>> whereExpression);

        T QuerySingle(Expression<Func<T, bool>> whereExpression);
    }
}
