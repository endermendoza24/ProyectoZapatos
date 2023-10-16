using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IToDosService
    {
        Task<List<ToDo>> GetAll();
        Task<ToDo> GetByIdAsync(Guid id);
        Task CreateAsync(ToDo toDo);
        Task UpdateAsync(ToDo toDo);
        Task DeleteAsync(ToDo toDo);
    }
}
