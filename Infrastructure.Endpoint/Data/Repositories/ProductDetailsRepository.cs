using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Interfaces;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ProductDetailsRepository : GenericRepository<ProductDetail>
    {
        public ProductDetailsRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder) : base(sqlDbConnection, operationBuilder)
        {
        }
    }
}
