using System;
using System.Collections.Generic;

namespace AdvancedBillingSystem.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<LineItem> LineItems { get; set; }
        public List<Discount> Discounts { get; set; }

        public Invoice()
        {
            LineItems = new List<LineItem>();
            Discounts = new List<Discount>();
        }

        public void AddLineItem(LineItem lineItem)
        {
            LineItems.Add(lineItem);
            TotalAmount += lineItem.Amount;
        }

        public void ApplyDiscount(Discount discount)
        {
            Discounts.Add(discount);
            TotalAmount -= discount.CalculateDiscount(TotalAmount);
        }

        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
        }
    }
}