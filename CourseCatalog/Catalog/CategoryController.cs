using RecipeCatalog.BLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using CourseCatalog.Catalog;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CookBook.BL.Controller
{
    public class CategoryController
    {
        MainRecipCatalog _catalog = new MainRecipCatalog();


        public CategoryController()
        {
            _catalog.Categories = GetCategories();
        }

        public List<Category> GetCategories()
        {
            if (File.Exists(_catalog.openCatalogFile))
                using (StreamReader file = File.OpenText(_catalog.openCatalogFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var data = serializer.Deserialize(file, typeof(Category)) as List<Category>;
                    return data;
                }
            else
                throw new ArgumentNullException("File not found!");

        }

        public void ShowCategories()
        {
            Console.WriteLine("Categories:");
            foreach (var item in _catalog.Categories)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}