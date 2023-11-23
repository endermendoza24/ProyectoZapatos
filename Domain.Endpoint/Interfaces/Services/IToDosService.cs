using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IToDosService
    {
        Task<List<ToDo>> GetAll();
        Task<ToDo> GetByIdAsync(int id);
        Task<ToDo> CreateAsync(CreateToDoDto toDo);
        Task<ToDo> UpdateAsync(int id, UpdateToDoDto toDo);
        Task<ToDo> DeleteAsync(int id);
    }
}
