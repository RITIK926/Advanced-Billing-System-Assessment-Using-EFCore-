using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedBillingSystem.Data;
using AdvancedBillingSystem.Entities;
using AdvancedBillingSystem.Repositories;
using AdvancedBillingSystem.Discounts;
using AdvancedBillingSystem.BillingStrategies;

namespace AdvancedBillingSystem.Services
{
    public class BillingService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly BillingDbContext _context;

        public BillingService(IInvoiceRepository invoiceRepository, BillingDbContext context)
        {
            _invoiceRepository = invoiceRepository;
            _context = context;
        }

        public async Task<Invoice> CreateInvoice(Tenant tenant, List<LineItem> lineItems, IDiscountPolicy discountPolicy, IBillingStrategy billingStrategy)
        {
            var invoice = new Invoice
            {
                TenantId = tenant.Id,
                LineItems = lineItems,
                State = InvoiceState.Created,
                TotalAmount = CalculateTotal(lineItems, discountPolicy, billingStrategy)
            };

            await _invoiceRepository.AddAsync(invoice);
            return invoice;
        }

        private decimal CalculateTotal(List<LineItem> lineItems, IDiscountPolicy discountPolicy, IBillingStrategy billingStrategy)
        {
            var subtotal = lineItems.Sum(item => item.Amount);
            var discount = discountPolicy.ApplyDiscount(subtotal);
            var total = billingStrategy.CalculateAmount(subtotal - discount);
            return total;
        }

        public async Task<Invoice> GetInvoiceById(Guid invoiceId)
        {
            return await _invoiceRepository.GetByIdAsync(invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesForTenant(Guid tenantId)
        {
            return await _invoiceRepository.GetInvoicesByTenantIdAsync(tenantId);
        }

        public async Task UpdateInvoiceState(Guid invoiceId, InvoiceState newState)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice != null)
            {
                invoice.State = newState;
                await _invoiceRepository.UpdateAsync(invoice);
            }
        }
    }
}