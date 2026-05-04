using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedBillingSystem.Entities;

namespace AdvancedBillingSystem.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly BillingDbContext _context;

        public InvoiceRepository(BillingDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.LineItems)
                .Include(i => i.Discount)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByTenantIdAsync(int tenantId)
        {
            return await _context.Invoices
                .Where(i => i.TenantId == tenantId)
                .Include(i => i.LineItems)
                .Include(i => i.Discount)
                .ToListAsync();
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await GetInvoiceByIdAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}