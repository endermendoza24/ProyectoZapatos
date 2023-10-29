using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Builders;
using Infrastructure.Endpoint.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class InvoicesRepository : GenericRepository<Invoice>
    {
        public InvoicesRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder) : base(sqlDbConnection, operationBuilder)
        {
        }

        public override async Task CreateAsync(Invoice entity)
        {
            SqlCommand invoiceCommand = operationBuilder.From(entity)
                .WithOperation(SqlWriteOperation.Create)
                .BuildWritter();
            List<SqlCommand> detailCommands = entity.InvoiceDetails.Select(invoiceDetail =>
            {
                return operationBuilder.From(invoiceDetail)
                 .WithOperation(SqlWriteOperation.Create)
                 .BuildWritter();
            }).ToList();

            List<SqlCommand> commands = new List<SqlCommand> { invoiceCommand };
            commands.AddRange(detailCommands);

            bool success = await sqlDbConnection.RunTransactionAsync(commands.ToArray());
        }
    }
}
