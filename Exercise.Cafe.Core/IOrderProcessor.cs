using System.Collections.Generic;

namespace Exercise.Cafe.Core
{
    internal interface IOrderProcessor
    {
        decimal GetTotalBill(List<Order> purchasedItems);
    }
}
