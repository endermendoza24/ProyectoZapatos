using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        public async Task<Marca> CreateAsync(CreateMarcaDTO marcaDTO)
        {
            Marca marca = new Marca
            {
                ID_MARCA = marcaDTO.ID_MARCA,
                estado = marcaDTO.estado,
                NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA
            };
            await marcaRepository.CreateAsync(marca);

            return marca;
        }

        //public async Task<Marca> DeleteAsync(int id) // Cambiado de Guid a int
        //{
        //    Marca marca = await GetByIdAsync(id);
        //    await marcaRepository.DeleteAsync(marca);
        //    return marca;
        //}

        public Task<List<Marca>> GetAll()
        {
            return marcaRepository.GetAsync();
        }

        public Task<Marca> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return marcaRepository.GetByIdAsync(id);
        }

        public async Task<Marca> UpdateAsync(int id, UpdateMarcaDTO marcaDTO) // Cambiado de Guid a int
        {
            Marca dbMarca = await GetByIdAsync(id);

            Marca marca = new Marca
            {
                NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA
            };

            await marcaRepository.UpdateAsync(marca);
            return marca;
        }
    }
}
