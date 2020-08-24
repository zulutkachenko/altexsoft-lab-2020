using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReseptCatalog_BL
{
    class ReseptCatalog
    {
        static void Main(string[] args)
        {
            var person = File.Exists(@"C:\Users\Виталий\Documents\GitHub\altexsoft-lab-2020\zulutkachenko\altexsoft-lab-2020\CourseCatalog\Catalog\Catalog.json") ? JsonConvert.DeserializeObject<MainCategory>(File.ReadAllText(@"C:\Users\Виталий\Documents\GitHub\altexsoft-lab-2020\zulutkachenko\altexsoft-lab-2020\CourseCatalog\Catalog\Catalog.json")) : new MainCategory();
        }
    }
}
