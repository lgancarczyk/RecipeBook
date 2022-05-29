using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Database.DbModels
{
    public class TagDbModel
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }

        public ICollection<RecipeTagDbModel> RecipeTagDbModels { get; set; }
    }
}
