namespace AdvancedBillingSystem.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string TenantId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<LineItemDto> LineItems { get; set; }
        public List<DiscountDto> Discounts { get; set; }
    }

    public class LineItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }

    public class DiscountDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
    }
}