using CourseCatalog.Catalog;
using Newtonsoft.Json;
using RecipeCatalog.BLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace CookBook.BL.Controller
{
    public class RecipeController
    {
        
        public List<Recipes> Recipes { get; set; }

        MainRecipesOpenFile _mainRecipeOpenFile = new MainRecipesOpenFile();
        MainRecipCatalog _mainRecipCatalog = new MainRecipCatalog();

        public RecipeController()
        {
            _mainRecipeOpenFile.Recipes = GetRecipes();
        }

        public List<Recipes> GetRecipes()
        {
            if (File.Exists(_mainRecipeOpenFile.openRecipeFile))
                using (StreamReader file = File.OpenText(_mainRecipeOpenFile.openRecipeFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var data = serializer.Deserialize(file, typeof(Recipes)) as List<Recipes>;
                    return data;
                }
            else
                throw new ArgumentNullException("File not found!");
        }

        public List<Recipes> GetSelectedRecipes(int numberSelectedCategory)
        {
            var recipesCategory = (from recipe in _mainRecipeOpenFile.Recipes
                                   where recipe.IdCategory == numberSelectedCategory
                                   select recipe).ToList<Recipes>();
            return recipesCategory;
        }

        public void ShowRecipesCategory(int numberSelectedCategory)
        {
            var recipesCategory = GetSelectedRecipes(numberSelectedCategory);
            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipesCategory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipesCategory[i].Name}");
            }
        }

        public void ShowSelectedRecipe(int numberSelectedRecipe, int numberSelectedCategory)
        {
            var rerecipesCategory = GetSelectedRecipes(numberSelectedCategory);
            Console.Clear();

            Console.WriteLine($"Name: {rerecipesCategory[numberSelectedRecipe - 1].Name}");
            Console.WriteLine($"Description: {rerecipesCategory[numberSelectedRecipe - 1].Description}");
            Console.WriteLine("Ingridients:");
            foreach (var item in rerecipesCategory[numberSelectedRecipe - 1].Ingredients)
            {
                Console.WriteLine($"{item.Name}: {item.Amount}");
            }
            Console.WriteLine("Cooking steps:");
            foreach (var item in rerecipesCategory[numberSelectedRecipe - 1].Steps)
            {
                Console.WriteLine($"{item.Number}. {item.Instruction}");
            }
        }

        public void SaveRecipes()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Recipes>));
            using (var file = new FileStream(_mainRecipeOpenFile.openRecipeFile, FileMode.Create))
            {
                jsonFormatter.WriteObject(file, _mainRecipeOpenFile.Recipes);
            }
        }

        public Recipes CreateRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();
            Console.Write("Please enter a description: ");
            string description = Console.ReadLine();
            Console.Write("Select a recipe category: ");
            int idCategory = int.Parse(Console.ReadLine());
            List<Ingredients> ingredients = new List<Ingredients>();
            while (true)
            {
                Console.Write("Enter the name of the ingredient: ");
                string nameIngredient = Console.ReadLine();
                Console.Write("Indicate the amount of the ingredient: ");
                double amountIngredient = double.Parse(Console.ReadLine());
                Ingredients ingredient = new Ingredients(nameIngredient, amountIngredient);
                ingredients.Add(ingredient);
                Console.WriteLine("Press ENTER to enter another ingredient or any other button to continue");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
            List<Steps> steps = new List<Steps>();
            int idStep = 0;
            while (true)
            {
                idStep++;
                Console.Write("Instructions for the cooking step: ");
                string stepInstruction = Console.ReadLine();
                Console.WriteLine("Press ENTER for next instruction or any other button to continue");
                Steps step = new Steps(idStep, stepInstruction);
                steps.Add(step);
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
            Recipes recipe = new Recipes(name, idCategory, description, ingredients, steps);
            return recipe;
        }
    }
}