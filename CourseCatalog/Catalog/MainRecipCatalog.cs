using RecipeCatalog.BLogic;
using System;
using System.Collections.Generic;

namespace CourseCatalog.Catalog
{
    public class MainRecipCatalog
    {
        public List<Category> Categories { get; set; }
        public readonly string openCatalogFile = @"Catalog.json";
    }

    public class MainRecipesOpenFile
    {
        public List<Recipes> Recipes { get; set; }
        public readonly string openRecipeFile = @"recept.json";
    }
}
