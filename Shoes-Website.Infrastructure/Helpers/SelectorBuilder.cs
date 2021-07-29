using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Shoes_Website.Infrastructure.Helpers
{
    public class SelectorBuilder<TSource, TResult>
    {
        public Expression<Func<TSource, TResult>> Selector { get; set; }

        public SelectorBuilder()
        {
            Selector = GetSelector();
        }

        private Expression<Func<TSource, TResult>> GetSelector()
        {
            ParameterExpression source = Expression.Parameter(typeof(TSource), "source");

            var bindings = new List<MemberBinding>();

            ValidateTResult();

            foreach (var prop in typeof(TResult).GetProperties())
            {
                var propExpression = Expression.PropertyOrField(source, prop.Name);
                var propConvertExpression = Expression.Convert(propExpression, prop.PropertyType);
                var binding = Expression.Bind(prop, propConvertExpression);
                bindings.Add(binding);
            }

            ParameterExpression[] parameters = new ParameterExpression[] { source };

            return Expression.Lambda<Func<TSource, TResult>>(
                Expression.MemberInit(Expression.New(typeof(TResult)), bindings),
                parameters);
        }

        private static void ValidateTResult()
        {
            var propSources = typeof(TSource).GetProperties().Select(x => x.Name);

            var propResults = typeof(TResult).GetProperties().Select(x => x.Name);

            foreach (var propName in propResults)
            {
                if (!propSources.Contains(propName))
                {
                    throw new ArgumentException(string.Format("Can not select Property: {0} from: {1}.", propName, typeof(TSource).Name));
                }
            }
        }
    }
}
