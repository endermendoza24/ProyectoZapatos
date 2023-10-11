using Domain.Endpoint.Entities;
using System.Data.SqlClient;

namespace Infrastructure.Endpoint.Data.Interfaces
{
    public enum SqlOperation
    {
        Create,
        Update,
        Delete
    }

    public interface ISqlOperationBuilder
    {
        IHaveSqlOperation From<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }

    public interface IHaveSqlOperation
    {
        IExecuteBuilder WithOperation(SqlOperation operation);
    }

    public interface IExecuteBuilder
    {
        SqlCommand Build();
    }
}
