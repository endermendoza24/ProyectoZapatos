using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Infrastructure.Endpoint.Data.Builders
{
    public class SqlEntitySettings
    {
        public string TableName { get; set; }
        public string Schema { get; set; }
        public List<SqlEntityPropertySettings> Properties { get; set; }
    }

    public class SqlEntityPropertySettings
    {
        public string PropertyName { get; set; }
        public SqlDbType SqlDbType { get; set; }
        public bool HasConversion => !(Conversion is null);
        public PropertyConversionData Conversion { get; set; } = null;
        public bool IsComplete { get; set; } = false;
    }

    public class PropertyConversionData
    {
        public dynamic OutgoingConversion { get; set; }
        public dynamic IncommingConversion { get; set; }
        public Type ProviderType { get; set; }
        public Type PropertyType { get; set; }
    }
}
