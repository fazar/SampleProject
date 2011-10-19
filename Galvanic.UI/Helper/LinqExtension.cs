using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Galvanic.UI.Helper
{
    public static class LinqExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction)
        {
            string methodName = string.Format("OrderBy{0}", direction.ToLower() == "asc" ? "" : "descending");
            ParameterExpression param = Expression.Parameter(query.ElementType, "p");

            MemberExpression memberAccess = null;
            foreach (var property in sortColumn.Split('.'))
                memberAccess = MemberExpression.Property(memberAccess ?? (param as Expression), property);

            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, param);
            MethodCallExpression result = Expression.Call(
                typeof(Queryable), 
                methodName,
                new[]
                {
                    query.ElementType, 
                    memberAccess.Type
                },
                query.Expression,   
                Expression.Quote(orderByLambda)
            );

            return query.Provider.CreateQuery<T>(result);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, string column, object value, WhereOperation where)
        {
            if (string.IsNullOrEmpty(column))
                return query;

            ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");

            MemberExpression memberAccess = null;
            foreach (var property in column.Split('.'))
                memberAccess = MemberExpression.Property
                   (memberAccess ?? (parameter as Expression), property);

            ConstantExpression filter = Expression.Constant
               (
                   Convert.ChangeType(value, memberAccess.Type)
               );


            Expression condition = null;
            LambdaExpression lambda = null;
            switch (where)
            {
                case WhereOperation.Equal:
                    condition = Expression.Equal(memberAccess, filter);
                    break;
                
                case WhereOperation.NotEqual:
                    condition = Expression.NotEqual(memberAccess, filter);
                    break;

                case WhereOperation.Contains:
                    condition = Expression.Call(memberAccess, typeof(string).GetMethod("Contains"), 
                        Expression.Constant(value));
                    break;
            }

            lambda = Expression.Lambda(condition, parameter);

            MethodCallExpression result = Expression.Call(
                typeof(Queryable), "Where",
                new[] { query.ElementType},
                query.Expression,
                lambda
            );

            return query.Provider.CreateQuery<T>(result);
        }
    }
}