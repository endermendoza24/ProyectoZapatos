using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IMarcaService
    {
        Task<List<Marca>> GetAll();
        Task<Marca> GetByIdAsync(Guid id);
        Task<Marca> CreateAsync(CreateMarcaDTO marcaDTO);
        Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Marca> DeleteAsync(Guid id);
        //Task<Marca> UpdateAsync(Guid id, UpdateTallasDto tallaDto);
        //Task<Marca> UpdateAsync(Guid id, UpdateTallasDto marcaDTO);
    }
}
