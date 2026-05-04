using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedBillingSystem.Entities;
using AdvancedBillingSystem.Repositories;
using AdvancedBillingSystem.Services;
using Moq;
using Xunit;

namespace AdvancedBillingSystem.UnitTests
{
    public class BillingServiceTests
    {
        private readonly Mock<IInvoiceRepository> _invoiceRepositoryMock;
        private readonly BillingService _billingService;

        public BillingServiceTests()
        {
            _invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            _billingService = new BillingService(_invoiceRepositoryMock.Object);
        }

        [Fact]
        public async Task CalculateTotalAmount_ShouldReturnCorrectTotal_WhenInvoicesExist()
        {
            // Arrange
            var invoices = new List<Invoice>
            {
                new Invoice { Id = 1, LineItems = new List<LineItem> { new LineItem { Amount = 100 } } },
                new Invoice { Id = 2, LineItems = new List<LineItem> { new LineItem { Amount = 200 } } }
            };

            _invoiceRepositoryMock.Setup(repo => repo.GetAllInvoicesAsync()).ReturnsAsync(invoices);

            // Act
            var totalAmount = await _billingService.CalculateTotalAmount();

            // Assert
            Assert.Equal(300, totalAmount);
        }

        [Fact]
        public async Task ApplyDiscount_ShouldReduceTotalAmount_WhenDiscountIsApplied()
        {
            // Arrange
            var invoice = new Invoice { Id = 1, LineItems = new List<LineItem> { new LineItem { Amount = 100 } } };
            var discount = new PercentageDiscount { Percentage = 10 };

            _invoiceRepositoryMock.Setup(repo => repo.GetInvoiceByIdAsync(1)).ReturnsAsync(invoice);

            // Act
            var totalAmountAfterDiscount = await _billingService.ApplyDiscount(1, discount);

            // Assert
            Assert.Equal(90, totalAmountAfterDiscount);
        }

        [Fact]
        public async Task GetInvoiceState_ShouldReturnCorrectState_WhenInvoiceExists()
        {
            // Arrange
            var invoice = new Invoice { Id = 1, State = "Paid" };

            _invoiceRepositoryMock.Setup(repo => repo.GetInvoiceByIdAsync(1)).ReturnsAsync(invoice);

            // Act
            var state = await _billingService.GetInvoiceState(1);

            // Assert
            Assert.Equal("Paid", state);
        }
    }
}