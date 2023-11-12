using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IColorService
    {
        Task<List<Color>> GetAll();
        Task<Color> GetByIdAsync(Guid id);
        Task<Color> CreateAsync(CreateColorDTO colorDTO);
        Task<Color> UpdateAsync(Guid id, UpdateMarcaDTO colorDTO);
        Task<Color> DeleteAsync(Guid id);
        //Task<Color> UpdateAsync(Guid id, UpdateTallasDto tallaDto);
        //Task<Color> UpdateAsync(Guid id, UpdateTallasDto colorDTO);
    }
}
