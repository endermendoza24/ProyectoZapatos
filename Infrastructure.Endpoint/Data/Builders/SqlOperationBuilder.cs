using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Data.SqlClient;

namespace Infrastructure.Endpoint.Data.Builders
{
    public sealed class SqlOperationBuilder : ISqlOperationBuilder
    {
        public IHaveSqlOperation From<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return new SqlOperationBuilder<TEntity>(entity);
        }
    }

    public class SqlOperationBuilder<TEntity> : IHaveSqlOperation, IExecuteBuilder where TEntity : BaseEntity
    {
        private readonly TEntity entity;
        private SqlOperation operation;

        public SqlOperationBuilder(TEntity entity)
        {
            this.entity = entity;
        }

        public IExecuteBuilder WithOperation(SqlOperation operation)
        {
            this.operation = operation;
            return this;
        }

        public SqlCommand Build()
        {
            throw new NotImplementedException();
        }
    }
}
