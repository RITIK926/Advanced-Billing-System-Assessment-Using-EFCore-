using System;
using System.Threading.Tasks;
using AdvancedBillingSystem.Entities;

namespace AdvancedBillingSystem.Services
{
    public class InvoiceStateService
    {
        public async Task<Invoice> ChangeInvoiceStateAsync(Invoice invoice, string newState)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            // Logic to change the state of the invoice
            invoice.State = newState;
            // Here you would typically save the changes to the database
            // await _dbContext.SaveChangesAsync();

            return invoice;
        }

        public string GetInvoiceState(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            return invoice.State;
        }
    }
}