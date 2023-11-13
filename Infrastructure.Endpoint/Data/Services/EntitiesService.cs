using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Builders;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Endpoint.Data.Services
{

    public class EntitiesService : IEntitiesService
    {
        private Dictionary<Type, SqlEntitySettings> entities = new Dictionary<Type, SqlEntitySettings>();
        private readonly ISqlEntitySettingsBuilder builder;

        public EntitiesService(ISqlEntitySettingsBuilder builder)
        {
            this.builder = builder;
            BuildEntities();
        }

        public SqlEntitySettings GetSettings<T>() where T : BaseEntity
        {
            //if (typeof(ToDo).Equals(typeof(T))) return BuildToDoSettings();
            if (!entities.ContainsKey(typeof(T))) throw new ArgumentOutOfRangeException(nameof(T), "Not Mapped Entity");

            return entities[typeof(T)];
        }

        private void BuildEntities()
        {
           
            SqlEntitySettings tallasSettings = BuildTallasSettings(); // Agrega esta línea
            SqlEntitySettings marcaSettings = BuildMarcaSettings();
            SqlEntitySettings colorSettings = BuildColorSettings();
            SqlEntitySettings materialSettings = BuildMaterialSettings();

          
            entities.Add(typeof(Tallas), tallasSettings); // Agrega esta línea
            entities.Add(typeof(Marca), marcaSettings);
            entities.Add(typeof(Color), colorSettings);
            entities.Add(typeof(Material), materialSettings);
        }

        private SqlEntitySettings BuildTallasSettings()
        {
            return builder.Entity<Tallas>(entity =>
            {
                entity.Table("TALLA"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.Num_Talla)
                    .SetDefaultName("NUM_TALLA") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_TALLA)
                    .SetDefaultName("ID_TALLA") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                    .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }
        private SqlEntitySettings BuildMaterialSettings()
        {
            return builder.Entity<Material>(entity =>
            {
                entity.Table("MATERIAL"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.estado)
                    .SetDefaultName("estado") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.Bit) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.detalles_material)
                   .SetDefaultName("detalles_material") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.NOMBRE_MATERIAL)
                   .SetDefaultName("NOMBRE_MATERIAL") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.ID_MATERIAL)
                    .SetDefaultName("ID_MATERIAL") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }
        private SqlEntitySettings BuildColorSettings()
        {
            return builder.Entity<Color>(entity =>
            {
                entity.Table("COLOR"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.NOMBRE_COLOR)
                    .SetDefaultName("NOMBRE_COLOR") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_COLOR)
                    .SetDefaultName("ID_COLOR") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                    .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }

        private SqlEntitySettings BuildMarcaSettings()
        {
            return builder.Entity<Marca>(entity =>
            {
                entity.Table("MARCA"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.NOMBRE_MARCA)
                    .SetDefaultName("NOMBRE_MARCA") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_MARCA)
                    .SetDefaultName("ID_MARCA") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.estado)
                   .SetDefaultName("estado") // Nombre de la columna en la base de datos para ID_TALLA
                   .WithSqlDbType(SqlDbType.Bit) // Tipo de datos en la base de datos
                   .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }

    }
}