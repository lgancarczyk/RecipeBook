using Microsoft.EntityFrameworkCore;
using RecipeBook.Core.DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.DBContext
{
    public class RecipeBookDbContext: DbContext
    {
        public RecipeBookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecipeDBModel> Recipes { get; set; }
    }
}
