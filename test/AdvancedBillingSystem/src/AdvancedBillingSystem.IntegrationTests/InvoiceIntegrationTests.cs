using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace AdvancedBillingSystem.IntegrationTests
{
    public class InvoiceIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InvoiceIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateInvoice_ReturnsCreatedStatus()
        {
            var invoiceDto = new
            {
                TenantId = 1,
                LineItems = new[]
                {
                    new { Description = "Service A", Amount = 100 },
                    new { Description = "Service B", Amount = 200 }
                },
                Discounts = new[]
                {
                    new { Type = "Percentage", Value = 10 }
                }
            };

            var response = await _client.PostAsJsonAsync("/api/invoices", invoiceDto);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetInvoice_ReturnsInvoiceDetails()
        {
            var response = await _client.GetAsync("/api/invoices/1");

            response.EnsureSuccessStatusCode();
            var invoice = await response.Content.ReadFromJsonAsync<InvoiceDto>();
            Assert.NotNull(invoice);
            Assert.Equal(1, invoice.Id);
        }

        [Fact]
        public async Task UpdateInvoice_ReturnsNoContent()
        {
            var invoiceUpdateDto = new
            {
                LineItems = new[]
                {
                    new { Description = "Service A", Amount = 150 }
                }
            };

            var response = await _client.PutAsJsonAsync("/api/invoices/1", invoiceUpdateDto);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteInvoice_ReturnsNoContent()
        {
            var response = await _client.DeleteAsync("/api/invoices/1");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}