﻿namespace Exercise.Cafe.Core
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public  ProductTemperatures Temperature { get; set; }

    }

    public enum ProductTemperatures
    {
        Hot,
        Cold
    }

}
