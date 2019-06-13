using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DatasetBuilder
{
    internal static class Extensions
    {
        internal static double Next(this Random random, Limits limits)
        {
            return random.NextDouble() * (limits.Max - limits.Min) + limits.Min;
        }

        internal static PropertyInfo GetPropertyInfo<TEntity, TLabel>(Expression<Func<TEntity, TLabel>> expression)
        {
            Expression memberExp;

            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var unary = expression.Body as UnaryExpression;
                memberExp = unary.Operand;
            }
            else
            {
                memberExp = expression.Body;
            }

            var propertyInfo = (memberExp as MemberExpression).Member as PropertyInfo;
            return propertyInfo;
        }
    }
}
