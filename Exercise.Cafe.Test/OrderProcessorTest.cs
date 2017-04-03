using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise.Cafe.Core;

namespace Exercise.Cafe.Test
{
    [TestClass]
    public class OrderProcessorTest
    {
        private readonly List<Product> _menuItems = new List<Product>
        {
            new Product
            {
                Name = "Cola",
                Price = new decimal(0.50),
                Temperature = ProductTemperatures.Cold
            },
            new Product
            {
                Name = "Coffee",
                Price = 1,
                Temperature = ProductTemperatures.Hot
            },
            new Product {Name = "Cheese Sandwich", Price = 2, Temperature = ProductTemperatures.Cold},
            new Product {Name = "Steak Sandwich", Price = new decimal(4.50), Temperature = ProductTemperatures.Hot}
        };

        [TestMethod]
        public void _Should_Return_Total_Bill_If_Menu_And_Purchased_Items_Are_Valid()
        {
            var purchasedItems = new List<string> {"Cola", "Coffee", "Cheese Sandwich"};
            var actualTotal = new OrderProcessor(_menuItems).GetStandardBill(purchasedItems);

            Assert.AreEqual(new decimal(3.50), actualTotal);
        }

        [TestMethod]
        public void _Should_Return_Zero_If_There_Is_No_Purchased_Items()
        {
            var actualTotal = new OrderProcessor(_menuItems).GetStandardBill(null);
            Assert.AreEqual(0, actualTotal);
        }

        [TestMethod]
        public void _Should_Throw_ArgumentNullException_If_Menu_Items_Id_Null()
        {
            try
            {
                var orderProcessor = new OrderProcessor(null);
                orderProcessor.GetStandardBill(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(nameof(_menuItems), ex.ParamName);
            }
            
        }

    }
}
