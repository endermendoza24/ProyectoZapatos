using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IToDosRepository
    {
        Task<List<ToDo>> GetAsync();
        Task<ToDo> GetByIdAsync(Guid id);
        Task CreateAsync(ToDo toDo);
        Task UpdateAsync(ToDo toDo);
        Task DeleteAsync(ToDo toDo);
    }
}
