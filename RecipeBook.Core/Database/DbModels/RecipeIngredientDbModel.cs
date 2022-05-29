using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Database.DbModels
{
    public class RecipeIngredientDbModel
    {
        public int RecipeId { get; set; }
        public RecipeDbModel RecipeDbModel { get; set; }
        public int IngredientId { get; set; }
        public IngredientDbModel IngredientDbModel { get; set; }
    }
}
