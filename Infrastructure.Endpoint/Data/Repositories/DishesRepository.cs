using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class DishesRepository : GenericRepository<Dish>, IDishesRepository
    {
        public DishesRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder) : base(sqlDbConnection, operationBuilder)
        {
        }

        public Task<List<Dish>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dish> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
