using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Website.Domain.Intefaces
{
    public interface IRepositoryBase
    {
        Task<T> GetByIdAsync<T>(int id) where T : EntityBase;

        Task<List<T>> ListAsync<T>() where T : EntityBase;

        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : EntityBase;

        Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>(ISpecification<T> spec) where T : EntityBase;

        Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>() where T : EntityBase;

        Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>(Expression<Func<T, TResult>> selector) where T : EntityBase;

        Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector) where T : EntityBase;

        Task<int> CountAsync<T>(ISpecification<T> spec) where T : EntityBase;

        Task<T> FirstOrDefaultAsync<T>(ISpecification<T> spec) where T : EntityBase;

        Task<TResult> FirstOrDefaultSelectAsync<T, TResult>(ISpecification<T> spec) where T : EntityBase;

        Task<TResult> FirstOrDefaultSelectAsync<T, TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector) where T : EntityBase;

        Task<bool> AnyAsync<T>(ISpecification<T> spec) where T : EntityBase;

        Task<T> AddAsync<T>(T entity) where T : EntityBase;

        void Update<T>(T entity) where T : EntityBase;

        void UpdateRange<T>(IEnumerable<T> entities) where T : EntityBase;

        void Delete<T>(T entity) where T : EntityBase;

        void DeleteRange<T>(IEnumerable<T> entities) where T : EntityBase;

        Task<int> ExecuteNonQueryAsync(string rawSql, params object[] parameters);

        Task<T> ExecuteScalarAsync<T>(string rawSql, params object[] parameters);
    }
}
