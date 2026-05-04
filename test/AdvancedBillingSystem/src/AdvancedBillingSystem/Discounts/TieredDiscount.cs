using System;
using System.Collections.Generic;

namespace AdvancedBillingSystem.Discounts
{
    public class TieredDiscount : IDiscountPolicy
    {
        public List<Tier> Tiers { get; set; }

        public TieredDiscount()
        {
            Tiers = new List<Tier>();
        }

        public decimal ApplyDiscount(decimal originalAmount)
        {
            decimal discountAmount = 0;

            foreach (var tier in Tiers)
            {
                if (originalAmount >= tier.Threshold)
                {
                    discountAmount = tier.DiscountAmount;
                }
            }

            return originalAmount - discountAmount;
        }
    }

    public class Tier
    {
        public decimal Threshold { get; set; }
        public decimal DiscountAmount { get; set; }

        public Tier(decimal threshold, decimal discountAmount)
        {
            Threshold = threshold;
            DiscountAmount = discountAmount;
        }
    }
}