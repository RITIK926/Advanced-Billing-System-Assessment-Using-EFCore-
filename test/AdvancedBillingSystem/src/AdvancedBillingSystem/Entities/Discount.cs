public class Discount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public bool IsPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    public bool IsValid()
    {
        return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
    }
}