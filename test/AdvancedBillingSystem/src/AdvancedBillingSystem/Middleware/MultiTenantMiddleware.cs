using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AdvancedBillingSystem.Middleware
{
    public class MultiTenantMiddleware
    {
        private readonly RequestDelegate _next;

        public MultiTenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Logic to resolve tenant from the request
            var tenantId = context.Request.Headers["X-Tenant-ID"].ToString();

            if (!string.IsNullOrEmpty(tenantId))
            {
                // Store tenant information in the HttpContext for later use
                context.Items["TenantId"] = tenantId;
            }

            await _next(context);
        }
    }
}