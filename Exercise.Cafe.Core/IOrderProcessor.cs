using System.Collections.Generic;

namespace Exercise.Cafe.Core
{
    internal interface IOrderProcessor
    {
        decimal GetStandardBill(List<string> purchasedItems);
    }
}
