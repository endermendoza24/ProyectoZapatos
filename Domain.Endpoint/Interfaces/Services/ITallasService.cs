using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Talla.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ITallasService
    {
        Task<List<Tallas>> GetAll();
        Task<Tallas> GetByIdAsync(int id);
        Task<Tallas> CreateAsync(CreateTallasDto tallasDto);
        Task<Tallas> UpdateAsync(int id, UpdateTallasDto tallasDto);
        Task<Tallas> DeleteAsync(int id);
        //Task<Tallas> UpdateAsync(Guid id, UpdateTallasDto tallaDto);
        //Task<Tallas> UpdateAsync(Guid id, UpdateTallasDto tallasDto);
    }
}
