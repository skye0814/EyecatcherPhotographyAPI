using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> query, bool isAscending, Expression<Func<T, object>> keySelector)
        {
            if (isAscending)
            {
                return query.OrderBy(keySelector);
            }
            else
            {
                return query.OrderByDescending(keySelector);
            }
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string orderBy, bool isAscending)
        {
            if (isAscending)
            {
                return query.OrderBy(ca => ca.GetType().GetProperty(orderBy).GetValue(ca, null));
            }
            else
            {
                return query.OrderByDescending(ca => ca.GetType().GetProperty(orderBy).GetValue(ca, null));
            }
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortBy, bool ascending)
        {
            var type = typeof(T);
            var property = type.GetProperty(sortBy);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp =
                Expression.Call(typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending",
                    new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
