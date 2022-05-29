using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Database.DbModels
{
    public class RecipeDbModel
    {
        [Key]
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<RecipeTagDbModel> RecipeTagDbModels { get; set; }

    }
}
