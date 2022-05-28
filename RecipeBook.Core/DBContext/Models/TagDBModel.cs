using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.DBContext.Models
{
    public class TagDBModel
    {
        public Guid TagID { get; set; }
        public string TagName { get; set; }
    }
}
