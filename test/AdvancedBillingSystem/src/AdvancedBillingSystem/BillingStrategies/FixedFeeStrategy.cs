using System;

namespace AdvancedBillingSystem.BillingStrategies
{
    public class FixedFeeStrategy : IBillingStrategy
    {
        private readonly decimal _fixedFee;

        public FixedFeeStrategy(decimal fixedFee)
        {
            _fixedFee = fixedFee;
        }

        public decimal CalculateBillingAmount()
        {
            return _fixedFee;
        }
    }
}