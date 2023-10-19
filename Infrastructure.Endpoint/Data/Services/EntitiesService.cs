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
            SqlEntitySettings toDoSettings = BuildToDoSettings();
            entities.Add(typeof(ToDo), toDoSettings);
        }

        private SqlEntitySettings BuildToDoSettings()
        {
            return builder.Entity<ToDo>(entity =>
            {
                entity.Table("ToDos");
                entity.Property(property => property.Id)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.UniqueIdentifier)
                    .AsPrimaryKey()
                    .AddProperty();
                entity.Property(property => property.Title)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.NVarChar)
                    .AddProperty();

                entity.Property(property => property.Description)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.NVarChar)
                    .AddProperty();

                entity.Property(property => property.Status)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.NVarChar)
                    .AddProperty();

                entity.Property(property => property.Done)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.Bit)
                    .AddProperty();

                entity.Property(property => property.CreatedAt)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.DateTime)
                    .AddProperty();

                entity.Property(property => property.StartedAt)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.DateTime)
                    .AddProperty();

                entity.Property(property => property.UpdatedAt)
                    .SetDefaultName()
                    .WithSqlDbType(SqlDbType.DateTime)
                    .AddProperty();
            }).Build();
        }
    }
}
