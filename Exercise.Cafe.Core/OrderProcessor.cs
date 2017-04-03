using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Cafe.Core
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly List<Product> _menuItems;
        public OrderProcessor(List<Product> menuItems)
        {
            _menuItems = menuItems;

            if (_menuItems == null)
            {
                throw new ArgumentNullException(nameof(_menuItems));
            }
        }

        public decimal GetStandardBill(List<string> purchasedItems)
        {
                return purchasedItems == null
                    ? 0
                    : _menuItems.Where(item => purchasedItems.Contains(item.Name)).Select(item => item.Price).Sum();
        }
    }
}
