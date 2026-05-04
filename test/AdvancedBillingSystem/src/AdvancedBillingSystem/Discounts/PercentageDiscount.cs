public class PercentageDiscount : IDiscountPolicy
{
    private readonly decimal _percentage;

    public PercentageDiscount(decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 100.");
        }
        _percentage = percentage;
    }

    public decimal ApplyDiscount(decimal originalAmount)
    {
        return originalAmount - (originalAmount * _percentage / 100);
    }
}