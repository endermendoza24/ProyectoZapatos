using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Interfaces;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class InvoicesRepository : GenericRepository<Invoice>
    {
        public InvoicesRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder) : base(sqlDbConnection, operationBuilder)
        {
        }
    }
}
