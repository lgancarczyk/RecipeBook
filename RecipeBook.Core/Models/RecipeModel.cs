using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Models
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int NoOfPortions { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
    }
}
