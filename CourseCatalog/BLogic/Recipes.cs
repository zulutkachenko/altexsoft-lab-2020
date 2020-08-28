using System;
using System.Collections.Generic;

namespace RecipeCatalog.BLogic
{
    [Serializable]
    public class Recipes
    {
        public string Name { get; set; }

        public int IdCategory { get; set; }

        public string Description { get; set; }

        public List<Ingredients> Ingredients { get; set; }

        public List<Steps> Steps { get; set; }

        public Recipes(string name, int idCategory, string description, List<Ingredients> ingredients, List<Steps> steps)
        {
            Name = name;
            IdCategory = idCategory;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
        }
    }
}