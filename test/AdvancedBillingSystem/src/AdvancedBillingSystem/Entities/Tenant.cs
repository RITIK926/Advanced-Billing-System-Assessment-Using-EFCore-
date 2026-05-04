public class Tenant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ConnectionString { get; set; }
    public string BillingStrategy { get; set; }
    public ICollection<Invoice> Invoices { get; set; }

    public Tenant()
    {
        Invoices = new List<Invoice>();
    }
}