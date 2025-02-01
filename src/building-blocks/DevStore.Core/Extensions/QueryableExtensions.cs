using Microsoft.EntityFrameworkCore;
using DevStore.Core.Models.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        private static object ConvertValue(string value, Type type)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(type);
            object propValue = typeConverter.ConvertFromString(value);

            return propValue;
        }
        private static Expression<Func<T, bool>> FilterGenerate<T>(List<Filter> filters)
        {
            Expression<Func<T, bool>> func = null;

            var type = typeof(T);
            var properties = type.GetProperties();

            ParameterExpression tpe = Expression.Parameter(typeof(T), "e");

            Expression body = tpe;

            Expression left = null;

            for (int i = 0; i < filters.Count; i++)
            {
                var prop = properties.Where(c => c.Name == filters[i].Property).FirstOrDefault();

                var value = Expression.Constant(ConvertValue(filters[i].Value, prop.PropertyType), prop.PropertyType);

                Expression right = Expression.Property(tpe, filters[i].Property);


                if (filters[i].Operator == Operator.LessThan)
                {
                    left = Expression.LessThan(right, value);
                }
                else if (filters[i].Operator == Operator.GreaterThan)
                {
                    left = Expression.GreaterThan(right, value);
                }
                else if (filters[i].Operator == Operator.Contains)
                {

                }
                else if (filters[i].Operator == Operator.StartsWith)
                {
                    left = Expression.Call(
                         right,
                         typeof(String).GetMethod("StartsWith",
                                        new Type[] { typeof(String) }),
                         value);

                    //body = Expression.(right, valor);
                }
                else if (filters[i].Operator == Operator.EndsWith)
                {
                    left = Expression.Call(
                         right,
                         typeof(String).GetMethod("EndsWith",
                                        new Type[] { typeof(String) }),
                         value);
                }
                else if (filters[i].Operator == Operator.Equals)
                {
                    left = Expression.Equal(right, value);
                }


                if (i > 0 && i < filters.Count)
                {
                    body = Expression.And(body, left);
                }
                else
                {
                    body = left;
                }
            }

            func = Expression.Lambda<Func<T, bool>>(body, tpe);

            return func;
        }

        public static IQueryable<TEntity> IncludeProperties<TEntity>(this IQueryable<TEntity> entities,
            params Expression<Func<TEntity, object>>[] properties) where TEntity : class
        {
            if (properties != null)
                entities = properties.Aggregate(entities, (current, include) => current.Include(include));

            return entities;
        }
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, List<Filter> filters)
        {
            ArgumentNullException.ThrowIfNull(source);

            if (filters.Count == 0)
                return source;

            var func = FilterGenerate<TSource>(filters);

            return source.Provider.CreateQuery<TSource>(
                Expression.Call(
                    null,
                    new Func<IQueryable<TSource>, Expression<Func<TSource, bool>>, IQueryable<TSource>>(Queryable.Where).Method,
                    source.Expression, Expression.Quote(func)));
        }
        public static IQueryable<TEntity> OrderMultiple<TEntity>(this IQueryable<TEntity> sources, List<Order> order) where TEntity : class
        {

            if (order.Count() == 0)
                return sources;

            var param = Expression.Parameter(typeof(TEntity), "e");

            MethodCallExpression expressCall = null;

            for (int i = 0; i < order.Count(); i++)
            {
                var propParam = Expression.PropertyOrField(param, order[i].Property);

                if (propParam != null)
                {
                    string method = GetDirection(order[i], i == 0);

                    var lambda = Expression.Lambda(propParam, param);

                    if (i == 0)
                    {
                        expressCall = Expression.Call(typeof(Queryable), method, new[] { param.Type, propParam.Type },
                               sources.AsQueryable().Expression, Expression.Quote(lambda));
                    }
                    else
                    {
                        expressCall = Expression.Call(typeof(Queryable), method, new[] { param.Type, propParam.Type },
                               expressCall, Expression.Quote(lambda));
                        //expressCall = Expression.Call(null, oMethod, lambda, lambda);
                    }
                }

            }

            return sources.Provider.CreateQuery<TEntity>(expressCall!);
        }

        private static string GetDirection(Order order, bool primary)
        {
            string method = string.Empty;

            switch (order.Direction)
            {
                case "asc":
                    if (primary)
                    {
                        method = "OrderBy";
                    }
                    else
                    {
                        method = "ThenBy";
                    }
                    break;
                case "desc":
                    if (primary)
                    {
                        method = "OrderByDescending";
                    }
                    else
                    {
                        method = "ThenByDescending";
                    }
                    break;
                case "":
                    if (primary)
                    {
                        method = "OrderBy";
                    }
                    else
                    {
                        method = "ThenBy";
                    }
                    break;
            }

            return method;
        }
    }

}



