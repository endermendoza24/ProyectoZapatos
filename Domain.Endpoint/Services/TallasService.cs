using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Talla.DTOs;

namespace Domain.Endpoint.Services
{
    public class TallasService : ITallasService
    {
        private readonly ITallasRepository tallasRepository;
        public TallasService(ITallasRepository tallasRepository)
        {
            this.tallasRepository = tallasRepository;
        }

        public async Task<Tallas> CreateAsync(CreateTallasDto tallaDto)
        {
            Tallas talla = new Tallas
            {
                //Id = Guid.NewGuid(),
                ID_TALLA= tallaDto.ID_TALLA,
                Num_Talla = tallaDto.NumTalla
            };
            await tallasRepository.CreateAsync(talla);

            return talla;
        }

        //public Task<Tallas> CreateAsync(CreateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Tallas> DeleteAsync(int id)
        {
            Tallas talla = await GetByIdAsync(id);
            await tallasRepository.DeleteAsync(talla);
            return talla;
        }

        public Task<List<Tallas>> GetAll()
        {
            return tallasRepository.GetAsync();
        }

        public Task<Tallas> GetByIdAsync(int id)
        {
            return tallasRepository.GetByIdAsync(id);
        }

        public async Task<Tallas> UpdateAsync(int id, UpdateTallasDto tallaDto)
        {
            Tallas dbTalla = await GetByIdAsync(id);

            Tallas talla = new Tallas
            {
                Id = dbTalla.Id,
                Num_Talla = tallaDto.NumTalla
            };

            await tallasRepository.UpdateAsync(talla);
            return talla;
        }

        //public Task<Tallas> UpdateAsync(Guid id, UpdateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
