using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ToDosService : IToDosService
    {
        private readonly IToDosRepository toDosRepository;
        public ToDosService(IToDosRepository toDosRepository)
        {
            this.toDosRepository = toDosRepository;
        }

        public Task CreateAsync(ToDo toDo)
        {
            return toDosRepository.CreateAsync(toDo);
        }

        public Task DeleteAsync(ToDo toDo)
        {
            return toDosRepository.DeleteAsync(toDo);
        }

        public Task<List<ToDo>> GetAll()
        {
            return toDosRepository.GetAsync();
        }

        public Task<ToDo> GetByIdAsync(Guid id)
        {
            return toDosRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(ToDo toDo)
        {
            return toDosRepository.UpdateAsync(toDo);
        }
    }
}
