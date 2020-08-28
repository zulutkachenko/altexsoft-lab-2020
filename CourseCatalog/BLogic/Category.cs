using System;
using System.Runtime.Serialization;

namespace RecipeCatalog.BLogic
{
    [Serializable]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}