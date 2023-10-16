using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Builders;
using Infrastructure.Endpoint.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        protected readonly ISqlCommandOperationBuilder operationBuilder;

        public GenericRepository(ISqlCommandOperationBuilder operationBuilder)
        {
            this.operationBuilder = operationBuilder;
        }

        public async Task<List<T>> GetAsync()
        {
            SqlCommand command = operationBuilder.Initialize<T>()
                .WithOperation(SqlReadOperation.Select)
                .BuildReader();

        }
    }
}
