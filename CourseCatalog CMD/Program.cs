using CookBook.BL.Controller;
using RecipeCatalog.BLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using CourseCatalog.Catalog;

namespace CookBook.CMD
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            CategoryController categoryController = new CategoryController();
            RecipeController recipeController = new RecipeController();
            MainRecipCatalog _catalog = new MainRecipCatalog();
            MainRecipesOpenFile mainRecipesOpenFile = new MainRecipesOpenFile();

            categoryController.ShowCategories();

            int numberSelectedCategory = GetNumberCategory(categoryController, _catalog);
            recipeController.ShowRecipesCategory(numberSelectedCategory);
            int numberSelectedRecipe = GetNumberRecipe(recipeController, numberSelectedCategory);
            recipeController.ShowSelectedRecipe(numberSelectedRecipe, numberSelectedCategory);

            Console.WriteLine("Create recipe?(y/n)");
            string choiceCreateRecipe = Console.ReadLine();
            if (choiceCreateRecipe.ToUpper() == "Y")
            {
                CreateRecipe(recipeController);
            }
            List<Ingredients> allingredients = new List<Ingredients>();
            allingredients = GetAllIngredients(recipeController);
            SaveIngredients(allingredients);
            Console.WriteLine("Show ingredients used in recipes?(y/n)");
            string choiceShowIngredient = Console.ReadLine();
            if (choiceShowIngredient.ToUpper() == "Y")
            {
                ShowAllIngredients(allingredients);
            }

            Console.WriteLine("");

            static int GetNumberCategory(CategoryController categoryController, MainRecipCatalog _catalog)
            {
                int numberSelectedCategory;

                do
                {
                    Console.Write("Select a category: ");
                    while (!int.TryParse(Console.ReadLine(), out numberSelectedCategory))
                    {
                        Console.WriteLine("Incorrect choice (enter number)");
                        Console.Write("Repeat selection: ");
                    }
                } while (numberSelectedCategory > _catalog.Categories.Count);
                return numberSelectedCategory;
            }

            static int GetNumberRecipe(RecipeController recipeController, int numberSelectedCategory)
            {
                List<Recipes> recipesCategory = recipeController.GetSelectedRecipes(numberSelectedCategory);
                int numberSelectedCRecipe;
                do
                {
                    Console.Write("Choose a recipe: ");
                    while (!int.TryParse(Console.ReadLine(), out numberSelectedCRecipe))
                    {
                        Console.WriteLine("Incorrect choice (enter number) ");
                        Console.Write("Repeat selection: ");
                    }
                } while (numberSelectedCRecipe > recipesCategory.Count);
                return numberSelectedCRecipe;
            }

            static Recipes CreateRecipe(RecipeController recipeController)
            {
                Console.WriteLine("Create recipe ");
                Recipes recipe = recipeController.CreateRecipe();
                recipeController.Recipes.Add(recipe);
                recipeController.SaveRecipes();
                return recipe;
            }

            static List<Ingredients> GetAllIngredients(RecipeController recipeController)
            {
                List<Ingredients> Ingredients = new List<Ingredients>();

                foreach (var recipe in recipeController.Recipes)
                {
                    var ingredients = recipe.Ingredients;
                    foreach (var item in ingredients)
                    {
                        Ingredients.Add(item);
                    }
                }

                return Ingredients;
            }
            static void SaveIngredients(List<Ingredients> allIngredients)
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(List<Ingredients>));
                using (var file = new FileStream("ingredient.json", FileMode.Create))
                {
                    jsonFormatter.WriteObject(file, allIngredients);
                }
            }
            static void ShowAllIngredients(List<Ingredients> allingredients)
            {
                foreach (var item in allingredients)
                {
                    Console.WriteLine($"-{item.Name}.");
                }
                Console.ReadLine();
            }
        }
    }
}