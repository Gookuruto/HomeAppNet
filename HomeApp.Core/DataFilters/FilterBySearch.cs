using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HomeApp.Core.DataFilters
{
    public static class FiltrationBySearch
    {
        public static IQueryable<T> FilterBySearch<T>(this IQueryable<T> query,PageFilter filter) where T : class
        {
            var itemParam = Expression.Parameter(typeof(T), "item");
            var properties = typeof(T).GetProperties().ToList();
            var sortExpression = Expression.Lambda<Func<T, object>>
            (Expression.Convert(Expression.Property(itemParam, filter.SortPropName), typeof(object)), itemParam);
            if (!properties.Any(x => string.Equals(x.Name, filter.SortPropName, StringComparison.OrdinalIgnoreCase) && filter.SortPropName != null)) throw new ArgumentException("Property with anme {0} doesn't exist", filter.SortPropName);
            var elements = Search(query, filter.SearchString, properties, itemParam);
            if (filter.SortDescending) {
                return elements.OrderByDescending<T, object>(sortExpression).Skip((filter.PageNumber - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
                    }
            else
            {
                return elements.OrderBy<T,object>(sortExpression).Skip((filter.PageNumber - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
            }
        }

        private static IQueryable<T> Search<T>(IQueryable<T> query,string? searchString,List<PropertyInfo> properties, ParameterExpression param)
        {
            List<Expression<Func<T, bool>>> expressionsList = new List<Expression<Func<T, bool>>>();
            searchString = searchString?.ToLower().Trim();
            if (string.IsNullOrEmpty(searchString)) return query;
            properties = properties.Where(x => x.PropertyType == typeof(string)).ToList();
            foreach(var prop in properties)
            {
                var propExpresion = Expression.Property(param, prop.Name);
                var stringExp = GetSearchStringExpression<T>(searchString, propExpresion, param);
                if (stringExp == null) continue;
                expressionsList.Add(stringExp);

            }
            var searchExpression = MergeWhereExpression(expressionsList);
            if(searchExpression == null)
            {
                return query;
            }
            return query.Where(searchExpression);
        }

        private static Expression<Func<T, bool>>? MergeWhereExpression<T>(List<Expression<Func<T, bool>>> expressionsList)
        {
            var parameter = Expression.Parameter(typeof(T));
            Expression<Func<T, bool>>? where = null;
            for (int i = 1; i < expressionsList.Count(); i++)
            {
                var rightSide = new ReplaceExpressionVisitor(expressionsList[i].Parameters[0], parameter);
                if (where == null)
                {
                    var leftSide = new ReplaceExpressionVisitor(expressionsList[i - 1].Parameters[0], parameter);
                    where = Expression.Lambda<Func<T, bool>>(
                        Expression.OrElse(leftSide.Visit(expressionsList[i - 1].Body), rightSide.Visit(expressionsList[i].Body))
                        );
                }
                else
                {
                    var leftSide = new ReplaceExpressionVisitor(expressionsList[i - 1].Parameters[0], parameter);
                    rightSide = new ReplaceExpressionVisitor(where.Parameters[0], parameter);
                    where = Expression.Lambda<Func<T, bool>>(
                        Expression.OrElse(leftSide.Visit(where.Body), rightSide.Visit(expressionsList[i].Body))
                        );
                }
            }
            return where;
        }

        private static Expression<Func<T,bool>> GetSearchStringExpression<T>(string search,MemberExpression propertyExp, ParameterExpression param)
        {
            var toLowerMethod = typeof(string).GetMethod("ToLower", new Type[0]);
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var toLower = Expression.Call(propertyExp, toLowerMethod);

            var constraints = Expression.Call(toLower, containsMethod, Expression.Constant(search));

            return Expression.Lambda<Func<T, bool>>(constraints, param);
        }

    }
}
