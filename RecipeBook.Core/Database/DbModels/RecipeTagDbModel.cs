using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Database.DbModels
{
    public class RecipeTagDbModel
    {
        public int RecipeId { get; set; }
        public RecipeDbModel RecipeDbModel { get; set; }
        public int TagId { get; set; }
        public TagDbModel TagDbModel { get; set; }
    }
}
