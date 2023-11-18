﻿using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository colorRepository;
        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public async Task<Color> CreateAsync(CreateColorDTO colorDTO)
        {
            Color color = new Color
            {
                //Id = Guid.NewGuid(),
                ID_COLOR = colorDTO.ID_COLOR,
                NOMBRE_COLOR = colorDTO.ID_COLOR
            };
            await colorRepository.CreateAsync(color);

            return color;
        }

        //public Task<Marca> CreateAsync(CreateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Color> DeleteAsync(Guid id)
        {
            Color color = await GetByIdAsync(id);
            await colorRepository.DeleteAsync(color);
            return color;
        }

        public Task<List<Color>> GetAll()
        {
            return colorRepository.GetAsync();
        }

        public Task<Color> GetByIdAsync(Guid id)
        {
            return colorRepository.GetByIdAsync(id);
        }

        public async Task<Color> UpdateAsync(Guid id, UpdateColorDTO colorDTO)
        {
            Color dbColor = await GetByIdAsync(id);

            Color color = new Color
            {
                //Id = dbMarca.Id, si hay algun error es aqui, descomentar esto
                NOMBRE_COLOR = colorDTO.NOMBRE_COLOR
            };

            await colorRepository.UpdateAsync(color);
            return color;
        }

        //public Task<Marca> UpdateAsync(Guid id, UpdateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
