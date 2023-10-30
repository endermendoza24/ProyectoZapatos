using Domain.Endpoint.Interfaces.Repositories;

namespace Domain.Endpoint.Services
{
    public class InvoicesService
    {
        private readonly IInvoicesRepository invoicesRepository;
        public InvoicesService(IInvoicesRepository invoicesRepository)
        {
            this.invoicesRepository = invoicesRepository;
        }
    }
}
