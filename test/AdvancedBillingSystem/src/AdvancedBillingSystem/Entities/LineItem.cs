public class LineItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Total => UnitPrice * Quantity;

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}