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

        private List<string> _purchasedItems;

        [TestMethod]
        public void _Should_Throw_ArgumentNullException_If_Menu_Items_Is_Null()
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

        [TestMethod]
        public void _Should_Return_Total_Bill_If_Purchased_Items_Are_Valid()
        {
             _purchasedItems = new List<string> {"Cola", "Coffee", "Cheese Sandwich"};
            var actualTotal = new OrderProcessor(_menuItems).GetStandardBill(_purchasedItems);

            Assert.AreEqual(new decimal(3.50), actualTotal);
        }

        [TestMethod]
        public void _Should_Return_Total_Bill_For_Valid_Purchased_Items_Only()
        {
             _purchasedItems = new List<string> { "Cola", "Coffee", "Chicken Sandwich" };
            var actualTotal = new OrderProcessor(_menuItems).GetStandardBill(_purchasedItems);

            Assert.AreEqual(new decimal(1.50), actualTotal);
        }

        [TestMethod]
        public void _Should_Return_Zero_If_There_Is_No_Valid_Purchased_Items()
        {
             _purchasedItems = new List<string> { "Coca Cola", "Black Coffee", "Chicken Sandwich" };
            var actualTotal = new OrderProcessor(_menuItems).GetStandardBill(_purchasedItems);
            Assert.AreEqual(0, actualTotal);
        }

        [TestMethod]
        public void _Should_Throw_ArgumentNullException_If_Purchased_Items_Is_Null()
        {
            try
            {
                var orderProcessor = new OrderProcessor(_menuItems);
                orderProcessor.GetStandardBill(_purchasedItems);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Purchased items cannot be null. Valid purchased items are required.", ex.Message);
            }
        }

    }
}
