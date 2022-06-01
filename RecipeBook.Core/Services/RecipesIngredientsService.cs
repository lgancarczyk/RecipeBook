using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Services
{
    /// <summary>
    /// Database queries to join tableof Recipes and Ingredients
    /// </summary>
    public static class RecipesIngredientsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="ingredientId"></param>
        /// <returns>True</returns>
        public static bool AddRecipesIngredientsRecord(int recipeId, int ingredientId)
        {
            try
            {
                var obj = new RecipeIngredientDbModel()
                {
                    RecipeId = recipeId,
                    IngredientId = ingredientId
                };
                using (var context = new MyDbContext())
                {
                    var addedRecord = context.RecipeIngredientDbModels.Add(obj);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"> recipe id</param>
        /// <returns>List of ingredients ids</returns>
        public static List<int> GetIngredientsIds(int recipeId)
        {
            using (var context = new MyDbContext())
            {
                return context.RecipeIngredientDbModels.Where(x => x.RecipeId == recipeId).Select(x => x.IngredientId).ToList();
            }
        }

    }
}
