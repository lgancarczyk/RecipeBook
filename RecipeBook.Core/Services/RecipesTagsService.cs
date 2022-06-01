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
    /// Database queries to join table of Recipes and Tags
    /// </summary>
    public static class RecipesTagsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="tagId"></param>
        /// <returns>bool</returns>
        public static bool AddRecipesTagsRecord(int recipeId, int tagId) 
        {
            try
            {
                var obj = new RecipeTagDbModel()
                {
                    RecipeId = recipeId,
                    TagId = tagId
                };
                using (var context = new MyDbContext())
                {
                    var addedRecipe = context.RecipeTagDbModels.Add(obj);
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
        /// <param name="recipeId"></param>
        /// <returns>list of tags ids that are connectoed tyo recipe</returns>
        public static List<int> GetTagsIds(int recipeId) 
        {
            using (var context = new MyDbContext())
            {
                return context.RecipeTagDbModels.Where(x => x.RecipeId == recipeId).Select(x => x.TagId).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns>list of recipes ids which contains given tag</returns>
        public static List<int> GetRecipesIds(int tagId)
        {
            using (var context = new MyDbContext())
            {
                return context.RecipeTagDbModels.Where(x => x.TagId == tagId).Select(x => x.RecipeId).ToList();
            }
        }
    }
}
