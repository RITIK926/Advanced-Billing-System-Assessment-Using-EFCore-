namespace AdvancedBillingSystem.Discounts
{
    public interface IDiscountPolicy
    {
        decimal ApplyDiscount(decimal originalAmount);
    }
}