using EntityFramework.Extensions;
using LibMgmtSys.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LibMgmtSys.DAL
{
    public class DAL<T> : IDAL<T> where T : class
    {
        public event EventHandler<DataChangedEventArgs<T>> OnDataChanged;

        public int Delete(Expression<Func<T, bool>> whereExpression)
        {
            using (var context = GetContext())
            {
                OnDataChanged?.BeginInvoke(this, new DataChangedEventArgs<T>(ChangedTypes.Deleted), null, null);
                return context.Set<T>().Where(whereExpression).Delete();
            }
        }

        public int Insert(T entity)
        {
            using (var context = GetContext())
            {
                OnDataChanged?.BeginInvoke(this, new DataChangedEventArgs<T>(ChangedTypes.Inserted), null, null);
                context.Set<T>().Add(entity);
                return context.SaveChanges();
            }
        }

        public IEnumerable<T> Insert(IEnumerable<T> entities)
        {
            using (var context = GetContext())
            {
                OnDataChanged?.BeginInvoke(this, new DataChangedEventArgs<T>(ChangedTypes.Inserted), null, null);
                context.Set<T>().AddRange(entities);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return entities;
                }

                return null;
            }
        }

        public T QuerySingle(Expression<Func<T, bool>> whereExpression)
        {
            using (var context = GetContext())
            {
                return context.Set<T>().SingleOrDefault(whereExpression);
            }
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> whereExpression)
        {
            using (var context = GetContext())
            {
                return context.Set<T>().Where(whereExpression);
            }
        }

        public int Update(T entity)
        {
            using (var context = GetContext())
            {
                context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }

        private LMSContext GetContext()
        {
            return new LMSContext();
        }
    }
}
