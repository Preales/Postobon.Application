using Application.Common.Application.Dtos;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace Application.Common.Utility
{
    public static class LinqExtension
    {
        public static IMemoryCache _cache;

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null) return right;
            var and = Expression.AndAlso(left.Body, right.Body);
            return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            // need to detect whether they use the same
            // parameter instance; if not, they need fixing
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                // simple version
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }
            // otherwise, keep expr1 "as is" and invoke expr2
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null) return right;
            var and = Expression.OrElse(left.Body, right.Body);
            return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, Pagination paginator)
        {
            Validator.Validate(paginator);

            var parameter = Expression.Parameter(typeof(T), "p");
            string[] properties = paginator.ColumnOrder.Split('.');
            MemberExpression mex = Expression.Property(parameter, properties[0]);
            for (int i = 1; i < properties.Length; i++)
            {
                mex = Expression.Property(mex, properties[i]);
            }
            var exp = Expression.Lambda(mex, parameter);

            string method = paginator.SortDirection == SortDirection.Asc ? "OrderBy" : "OrderByDescending";

            Type[] types = new Type[] { query.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, query.Expression, exp);
            var temp = query.Provider.CreateQuery<T>(mce)
                .Skip(paginator.StartIndex);

            return paginator.PageSize == 0 ?
                temp :
                temp.Take(paginator.PageSize);
        }

        public static List<T> ToListCache<T>(this IQueryable<T> @this)
        {
            if (_cache == null)
                throw new ArgumentException("Debes definir el cache antes de usar este metodo");

            List<T> items = null;
            var key = typeof(T).FullName;
            var cacheItems = (List<T>)_cache.Get(key);
            if (cacheItems != null && cacheItems.Count() > 0)
            {
                items = cacheItems;
            }
            else
            {
                items = @this.ToList();
                _cache.Set<List<T>>(key, items, DateTimeOffset.Now.AddHours(12));
            }
            return items;
        }

        public static List<T> Unique<T>(this List<T> input)
        {
            HashSet<string> uniqueHashes = new HashSet<string>();
            List<T> uniqueItems = new List<T>();

            input.ForEach(x =>
            {
                string hashCode = ComputeHash(x);

                if (uniqueHashes.Contains(hashCode))
                {
                    return;
                }

                uniqueHashes.Add(hashCode);
                uniqueItems.Add(x);
            });

            return uniqueItems;
        }

        private static string ComputeHash<T>(T entity)
        {
#pragma warning disable SYSLIB0021 // El tipo o el miembro están obsoletos
            System.Security.Cryptography.SHA1CryptoServiceProvider sh = new System.Security.Cryptography.SHA1CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // El tipo o el miembro están obsoletos
            string input = JsonConvert.SerializeObject(entity);

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = sh.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }
    }
}
