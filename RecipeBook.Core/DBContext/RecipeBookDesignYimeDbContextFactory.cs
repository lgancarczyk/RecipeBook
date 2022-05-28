using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.DBContext
{
    public class RecipeBookDesignYimeDbContextFactory : IDesignTimeDbContextFactory<RecipeBookDbContext>

    {
        public RecipeBookDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source = recipeBook.db").Options;
            return new RecipeBookDbContext(options);
        }
    }
}
