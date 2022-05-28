using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.DBContext.Models
{
    public class RecipeDBModel
    {
        [Key]
        public Guid RecipeId { get; set; }
        public string Title { get; set; }
    }
}
