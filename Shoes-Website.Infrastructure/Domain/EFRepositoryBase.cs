using System;
using System.Linq;
using Shoes_Website.Domain;
using Ardalis.Specification;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Infrastructure.Helpers;
using Ardalis.Specification.EntityFrameworkCore;

namespace Shoes_Website.Infrastructure.Domain
{
    public class EFRepositoryBase : IRepositoryBase
    {
        private const int COMMAND_TIMEOUT_SECONDS = 360;
        private readonly DbContext _dbContext;

        public EFRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync<T>(T entity) where T : EntityBase
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<bool> AnyAsync<T>(ISpecification<T> spec) where T : EntityBase
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.AnyAsync();
        }

        public async Task<int> CountAsync<T>(ISpecification<T> spec) where T : EntityBase
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.CountAsync();
        }

        public void Delete<T>(T entity) where T : EntityBase
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : EntityBase
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task<int> ExecuteNonQueryAsync(string rawSql, params object[] parameters)
        {
            var connection = _dbContext.Database.GetDbConnection();

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var sqlTxn = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandTimeout = COMMAND_TIMEOUT_SECONDS;
                    command.CommandText = rawSql;
                    command.Transaction = sqlTxn;

                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            command.Parameters.Add(p);
                        }
                    }

                    var result = await command.ExecuteNonQueryAsync();
                    sqlTxn.Commit();

                    return result;
                }
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string rawSql, params object[] parameters)
        {
            var connection = _dbContext.Database.GetDbConnection();

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandTimeout = COMMAND_TIMEOUT_SECONDS;
                command.CommandText = rawSql;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        command.Parameters.Add(p);
                    }
                }

                return (T)await command.ExecuteScalarAsync();
            }
        }

        public async Task<T> FirstOrDefaultAsync<T>(ISpecification<T> spec) where T : EntityBase
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.FirstOrDefaultAsync();
        }

        public async Task<TResult> FirstOrDefaultSelectAsync<T, TResult>(ISpecification<T> spec) where T : EntityBase
        {
            var selector = new SelectorBuilder<T, TResult>().Selector;

            var specificationResult = ApplySpecification(spec).Select(selector);

            return await specificationResult.FirstOrDefaultAsync();
        }

        public async Task<TResult> FirstOrDefaultSelectAsync<T, TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector) where T : EntityBase
        {
            var specification = ApplySpecification(spec).Select(selector);
            return await specification.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : EntityBase
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<List<T>> ListAsync<T>() where T : EntityBase
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : EntityBase
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>(ISpecification<T> spec) where T : EntityBase
        {
            var selector = new SelectorBuilder<T, TResult>().Selector;
            var specificationResult = ApplySpecification(spec)
                .Select(selector);

            return await specificationResult.ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>() where T : EntityBase
        {
            var selector = new SelectorBuilder<T, TResult>().Selector;
            var specificationResult = _dbContext.Set<T>()
                .Select(selector);

            return await specificationResult.ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>(Expression<Func<T, TResult>> selector) where T : EntityBase
        {
            var specificationResult = _dbContext.Set<T>().ToList().AsQueryable().Select(selector);
            return await specificationResult.ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListSelectAsync<T, TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector) where T : EntityBase
        {
            var specificationResult = ApplySpecification(spec).Select(selector);
            return await specificationResult.ToListAsync();
        }

        public void Update<T>(T entity) where T : EntityBase
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : EntityBase
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        protected IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : EntityBase
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
