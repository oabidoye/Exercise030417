using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise.Cafe.Core;

namespace Exercise.Cafe.Test
{
    [TestClass]
    public class StepTwoOrderProcessorTest
    {
        private List<Order> _purchasedItems;

        [TestMethod]
        public void _Should_Return_Zero_If_There_Is_No_Purchased_Item()
        {
            var actualTotal = new OrderProcessor().GetTotalBill(new List<Order>());
            Assert.AreEqual(0, actualTotal);
        }

        [TestMethod]
        public void _Should_Throw_ArgumentNullException_If_Purchased_Items_Is_Null()
        {
            try
            {
                var orderProcessor = new OrderProcessor();
                orderProcessor.GetTotalBill(_purchasedItems);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Purchased items cannot be null. Valid purchased items are required.", ex.Message);
            }
        }

        [TestMethod]
        public void _Should_Return_Total_Bill_Without_ServiceCharge_For_Purchased_Drink_Items()
        {
            _purchasedItems = new List<Order>
            {
                new Order
                {
                    Quantity = 2,
                    Item =
                        new Product
                        {
                            Name = "Coffee",
                            Price = 1,
                            Type = ProductTypes.Drink,
                            Temperature = ProductTemperatures.Hot
                        }
                },
                new Order
                {
                    Quantity = 1,
                    Item =
                        new Product
                        {
                            Name = "Cola",
                            Price = new decimal(0.50),
                            Type = ProductTypes.Drink,
                            Temperature = ProductTemperatures.Cold
                        }
                }
            };

          
            var actualTotal = new OrderProcessor().GetTotalBill(_purchasedItems);

            Assert.AreEqual(new decimal(2.50), actualTotal);
        }

        [TestMethod]
        public void _Should_Return_Total_Bill_Including_ServiceCharge_For_Purchased_Food_Items()
        {
            _purchasedItems = new List<Order>
            {
                new Order
                {
                    Quantity = 2,
                    Item =
                        new Product
                        {
                            Name = "Chicken Sandwich",
                            Price = 3,
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Cold
                        }
                },
                new Order
                {
                    Quantity = 1,
                    Item =
                        new Product
                        {
                            Name = "Cheese Sanwich",
                            Price = new decimal(2.50),
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Cold
                        }
                }
            };

            var actualTotal = new OrderProcessor().GetTotalBill(_purchasedItems);

            Assert.AreEqual(new decimal(9.35), actualTotal);
        }

        [TestMethod]
        public void _Should_Return_Total_Bill_Including_ServiceCharge_For_Purchased_Hot_Food_Items()
        {
            _purchasedItems = new List<Order>
            {
                new Order
                {
                    Quantity = 2,
                    Item =
                        new Product
                        {
                            Name = "Chicken Sandwich",
                            Price = 3,
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Hot
                        }
                },
                new Order
                {
                    Quantity = 1,
                    Item =
                        new Product
                        {
                            Name = "Steak Sandwich",
                            Price = new decimal(4.50),
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Hot
                        }
                },
                new Order
                {
                    Quantity = 1,
                    Item =
                        new Product
                        {
                            Name = "Cheese Sanwich",
                            Price = new decimal(2.50),
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Cold
                        }
                }
            };

            var actualTotal = new OrderProcessor().GetTotalBill(_purchasedItems);

            Assert.AreEqual(new decimal(15.60), actualTotal);
        }

        [TestMethod]
        public void _Should_Return_Total_Bill_Including_Maximum_TwentyPounds_ServiceCharge_For_Purchased_Hot_Food_Items()
        {
            _purchasedItems = new List<Order>
            {
                new Order
                {
                    Quantity = 2,
                    Item =
                        new Product
                        {
                            Name = "Chicken Sandwich",
                            Price = 3,
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Hot
                        }
                },
                new Order
                {
                    Quantity = 10,
                    Item =
                        new Product
                        {
                            Name = "Steak Sandwich",
                            Price = new decimal(14.50),
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Hot
                        }
                },
                new Order
                {
                    Quantity = 15,
                    Item =
                        new Product
                        {
                            Name = "Steak",
                            Price = new decimal(18.50),
                            Type = ProductTypes.Food,
                            Temperature = ProductTemperatures.Cold
                        }
                }
            };

            var actualTotal = new OrderProcessor().GetTotalBill(_purchasedItems);

            Assert.AreEqual(new decimal(448.50), actualTotal);
        }

    }
}
