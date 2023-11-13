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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<Material> CreateAsync(CreateMaterialDTO materialDTO)
        {
            Material material = new Material
            {
                //Id = Guid.NewGuid(),
                ID_MATERIAL = materialDTO.ID_MATERIAL,
                estado= materialDTO.estado,
                detalles_material= materialDTO.detalles_material,
                NOMBRE_MATERIAL= materialDTO.NOMBRE_MATERIAL
            };
            await materialRepository.CreateAsync(material);

            return material;
        }

        //public Task<Tallas> CreateAsync(CreateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Material> DeleteAsync(Guid id)
        {
            Material material = await GetByIdAsync(id);
            await materialRepository.DeleteAsync(material);
            return material;
        }

        public Task<List<Material>> GetAll()
        {
            return materialRepository.GetAsync();
        }

        public Task<Material> GetByIdAsync(Guid id)
        {
            return materialRepository.GetByIdAsync(id);
        }

        public async Task<Material> UpdateAsync(Guid id, UpdateMaterialDTO materialDTO)
        {
            Material dbMaterial = await GetByIdAsync(id);

            Material material = new Material
            {                
                estado = materialDTO.estado,
                detalles_material = materialDTO.detalles_material,
                NOMBRE_MATERIAL = materialDTO.NOMBRE_MATERIAL
            };

            await materialRepository.UpdateAsync(material);
            return material;
        }

        //public Task<Tallas> UpdateAsync(Guid id, UpdateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
