using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Database.DbModels
{
    public class IngredientDbModel
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public ICollection<RecipeIngredientDbModel> RecipeIngredientDbModels { get; set; }
    }
}
