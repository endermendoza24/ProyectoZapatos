using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Interfaces;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ProductsRepository : GenericRepository<Product>
    {
        public ProductsRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder) : base(sqlDbConnection, operationBuilder)
        {
        }
    }
}
