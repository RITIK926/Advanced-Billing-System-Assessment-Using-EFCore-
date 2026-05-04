namespace AdvancedBillingSystem.BillingStrategies
{
    public interface IBillingStrategy
    {
        decimal CalculateBillingAmount(decimal baseAmount, int usage);
    }
}