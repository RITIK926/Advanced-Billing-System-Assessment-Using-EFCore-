namespace AdvancedBillingSystem.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetInvoicesByTenantIdAsync(int tenantId);
        Task AddInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        Task DeleteInvoiceAsync(int id);
    }
}