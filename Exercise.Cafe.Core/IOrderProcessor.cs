using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Cafe.Core
{
    internal interface IOrderProcessor
    {
        decimal GetStandardBill(List<string> purchasedItems);
    }
}
