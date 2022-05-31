using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Services
{
    public static class RecipesService
    {
        public static int AddRecipe(RecipeDbModel recipe)
        {
            using (var context = new MyDbContext())
            {
                var addedRecipe = context.Recipes.Add(recipe);
                context.SaveChanges();
                return addedRecipe.Entity.RecipeId;
            }
        }

        public static List<RecipeDbModel> GetAllRecipes() 
        {
            using (var context = new MyDbContext())
            {
                return context.Recipes.ToList();
            }
        }

        public static List<RecipeDbModel> GetRecipesByTitle(string _title)
        {
            using (var context = new MyDbContext())
            {
                return context.Recipes.Where(x => x.Title.Contains(_title)).ToList();
            }
        }

        public static RecipeDbModel GetRecipe(int recipeId)
        {
            using (var context = new MyDbContext())
            {
                return context.Recipes.Where(x => x.RecipeId == recipeId).Single();
            }
        }
        
    }
}
