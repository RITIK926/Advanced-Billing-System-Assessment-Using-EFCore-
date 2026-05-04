using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedBillingSystem.Entities;
using AdvancedBillingSystem.Data;

namespace AdvancedBillingSystem.Services
{
    public class TenantService
    {
        private readonly BillingDbContext _context;

        public TenantService(BillingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tenant>> GetAllTenantsAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task<Tenant> GetTenantByIdAsync(int tenantId)
        {
            return await _context.Tenants.FindAsync(tenantId);
        }

        public async Task AddTenantAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTenantAsync(Tenant tenant)
        {
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTenantAsync(int tenantId)
        {
            var tenant = await _context.Tenants.FindAsync(tenantId);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();
            }
        }
    }
}