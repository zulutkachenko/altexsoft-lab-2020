using System;

namespace RecipeCatalog.BLogic
{
    [Serializable]
    public class Ingredients
    {
        public string Name { get; set; }

        public double Amount { get; set; }

        public Ingredients(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}