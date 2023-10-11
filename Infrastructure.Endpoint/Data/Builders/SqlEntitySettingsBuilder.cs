using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Endpoint.Data.Builders
{
    public sealed class SqlEntitySettingsBuilder : ISqlEntitySettingsBuilder
    {
        public IExecuteEntityBuilder Entity<TEntity>(Action<IHaveTableSettings<TEntity>> action) where TEntity : BaseEntity
        {
            var entityBuilder = new SqlEntitySettingsBuilder<TEntity>();
            action.Invoke(entityBuilder);
            return entityBuilder;
        }
    }

    public class SqlEntitySettingsBuilder<TEntity> : IHaveTableSettings<TEntity>, IExecuteEntityBuilder where TEntity : BaseEntity
    {
        private string _tableName;
        private string _schema = string.Empty;
        private List<SqlEntityPropertySettings> _properties = new List<SqlEntityPropertySettings>();

        public void Table(string tableName)
        {
            _tableName = tableName;
        }

        public void Table(string tableName, string schema)
        {
            _tableName = tableName;
            _schema = schema;
        }

        public IHavePropertyName<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> keyExpression)
        {
            var sqlPropetySettings = new SqlPropertySettingsBuilder<TEntity, TProperty>(keyExpression);
            _properties.Add(sqlPropetySettings.Settings);
            return sqlPropetySettings;
        }


        public SqlEntitySettings Build()
        {
            return new SqlEntitySettings
            {
                TableName = _tableName,
                Schema = _schema,
                Properties = _properties.Where(prop => prop.IsComplete).ToList(),
            };
        }
    }

    public class SqlPropertySettingsBuilder<TEntity, TProperty> :
        IHavePropertyName<TEntity, TProperty>,
        IHaveSqlDbType<TEntity, TProperty>,
        IHaveConversion<TEntity, TProperty>,
        IAddPropertySettings
        where TEntity : BaseEntity
    {
        public SqlEntityPropertySettings Settings = new SqlEntityPropertySettings();
        private readonly Expression<Func<TEntity, TProperty>> _lambdaExpression;

        public SqlPropertySettingsBuilder(Expression<Func<TEntity, TProperty>> lambdaExpression)
        {
            _lambdaExpression = lambdaExpression;
        }

        public IHaveSqlDbType<TEntity, TProperty> WithName(string name)
        {
            Settings.PropertyName = name;
            return this;
        }

        public IHaveSqlDbType<TEntity, TProperty> SetDefaultName()
        {
            Settings.PropertyName = GetName(_lambdaExpression);
            return this;
        }

        private string GetName(Expression<Func<TEntity, TProperty>> lambdaExpression)
        {
            MemberExpression body = lambdaExpression.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)lambdaExpression.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }

        public IHaveConversion<TEntity, TProperty> WithSqlDbType(SqlDbType sqlDbType)
        {
            Settings.SqlDbType = sqlDbType;
            return this;
        }

        public IAddPropertySettings WithConversion<TProvider>(
            Expression<Func<TProperty, TProvider>> outgoing,
            Expression<Func<TProvider, TProperty>> incomming)
        {
            var conversion = new PropertyConversionData()
            {
                OutgoingConversion = outgoing.Compile(),
                IncommingConversion = incomming.Compile(),
                ProviderType = typeof(TProvider),
                PropertyType = typeof(TProperty)
            };

            Settings.Conversion = conversion;
            return this;
        }

        public void AddProperty()
        {
            Settings.IsComplete = true;
        }
    }
}
