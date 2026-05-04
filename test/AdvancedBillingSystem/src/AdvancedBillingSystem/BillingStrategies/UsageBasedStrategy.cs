using System;

namespace AdvancedBillingSystem.BillingStrategies
{
    public class UsageBasedStrategy : IBillingStrategy
    {
        private readonly decimal _ratePerUnit;

        public UsageBasedStrategy(decimal ratePerUnit)
        {
            _ratePerUnit = ratePerUnit;
        }

        public decimal CalculateBill(int unitsUsed)
        {
            if (unitsUsed < 0)
            {
                throw new ArgumentException("Units used cannot be negative.");
            }

            return unitsUsed * _ratePerUnit;
        }
    }
}