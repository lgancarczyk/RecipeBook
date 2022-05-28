using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.DBContext.Models
{
    public class IngredientDBModel
    {
        public Guid IngredientID { get; set; }
        public string IngredientName { get; set; }
    }
}
