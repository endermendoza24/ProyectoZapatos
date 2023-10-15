using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ToDosRepository : IToDosRepository
    {

        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlEntitySettingsBuilder _builder;

        public ToDosRepository(ISqlDbConnection sqlDbConnection, ISqlEntitySettingsBuilder builder)
        {
            _sqlDbConnection = sqlDbConnection;
            _builder = builder;
        }

        public async Task<List<ToDo>> Get()
        {
            const string sqlQuery = "SELECT * FROM ToDos;";
            DataTable dataTable = await _sqlDbConnection.ExecuteQueryCommandAsync(sqlQuery);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        private ToDo MapEntityFromDataRow(DataRow row)
        {
            ToDo toDo = new ToDo
            {
                Id = _sqlDbConnection.GetDataRowValue<Guid>(row, "Id"),
                Title = _sqlDbConnection.GetDataRowValue<string>(row, "Title"),
                Description = _sqlDbConnection.GetDataRowValue<string>(row, "Description"),
                Done = _sqlDbConnection.GetDataRowValue<bool>(row, "Done"),
                Status = (ToDoStatus)Enum.Parse(typeof(ToDoStatus), _sqlDbConnection.GetDataRowValue<string>(row, "Status")),
                CreatedAt = _sqlDbConnection.GetDataRowValue<DateTime>(row, "CreatedAt"),
                StartedAt = _sqlDbConnection.GetDataRowValue<DateTime?>(row, "StartedAt"),
                UpdatedAt = _sqlDbConnection.GetDataRowValue<DateTime?>(row, "UpdatedAt"),
            };

            return toDo;
        }
    }
}
