using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Models
{
    public class RecipeModel
    {
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public int CookingTime { get; set; }
        public int NumberOfPortions { get; set; }
        public List<string> Ingredients { get; set; }
        public string Description { get; set; }
    }
}
