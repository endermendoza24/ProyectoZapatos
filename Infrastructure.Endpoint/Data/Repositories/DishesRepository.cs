using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Interfaces;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class DishesRepository : GenericRepository<Dish>
    {
        public DishesRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder) : base(sqlDbConnection, operationBuilder)
        {
        }
    }
}
