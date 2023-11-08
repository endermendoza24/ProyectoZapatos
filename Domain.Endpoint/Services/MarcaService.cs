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
                //Id = Guid.NewGuid(),
                ID_MARCA = marcaDTO.ID_MARCA,
                estado= marcaDTO.estado,
                NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA
            };
            await marcaRepository.CreateAsync(marca);

            return marca;
        }

        //public Task<Marca> CreateAsync(CreateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Marca> DeleteAsync(Guid id)
        {
            Marca marca = await GetByIdAsync(id);
            await marcaRepository.DeleteAsync(marca);
            return marca;
        }

        public Task<List<Marca>> GetAll()
        {
            return marcaRepository.GetAsync();
        }

        public Task<Marca> GetByIdAsync(Guid id)
        {
            return marcaRepository.GetByIdAsync(id);
        }

        public async Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO)
        {
            Marca dbMarca = await GetByIdAsync(id);

            Marca marca = new Marca
            {
                //Id = dbMarca.Id, si hay algun error es aqui, descomentar esto
                NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA
            };

            await marcaRepository.UpdateAsync(marca);
            return marca;
        }

        //public Task<Marca> UpdateAsync(Guid id, UpdateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
