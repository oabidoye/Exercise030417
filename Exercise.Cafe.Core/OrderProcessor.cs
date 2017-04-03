using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Cafe.Core
{
    public class OrderProcessor : IOrderProcessor
    {
        public decimal GetTotalBill(List<Order> purchasedItems)
        {
            if (purchasedItems == null)
            {
                throw new ArgumentNullException("Purchased items cannot be null. Valid purchased items are required.", new Exception());
            }

            var totalBill = purchasedItems.Select(p => p.Item.Price * p.Quantity).Sum();

            if (purchasedItems.Any(p => p.Item.Type == ProductTypes.Food))
            {
               //Add service charge to the total bill

                totalBill = totalBill +
                            GetServiceCharge(totalBill,
                                purchasedItems.Any(p => p.Item.Temperature == ProductTemperatures.Hot));
            }

            return Math.Round(totalBill, 2); 
        }

        private static decimal GetServiceCharge(decimal totalBill, bool isHotFood)
        {
            var serviceCharge = (totalBill * 10) / 100; 

            if (isHotFood)
            {
                serviceCharge = (totalBill*20)/100;
            }

            serviceCharge = Math.Round(serviceCharge, 2);

            return serviceCharge > 20 ? 20 : serviceCharge;
        }



    }
}
