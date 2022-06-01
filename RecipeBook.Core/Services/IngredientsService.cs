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
    /// Database queries to Ingredients Table
    /// </summary>
    public static class IngredientsService
    {

        /// <summary>
        /// Adds Ingerdient to a database
        /// </summary>
        /// <param name="ingredientName"> ingredient name in string like "carrot"</param>
        /// <returns>ingredientId</returns>
        public static int AddIngredient(string ingredientName)
        {
            using (var context = new MyDbContext())
            {
                var ingredientId = FindIngredient(ingredientName);

                if (ingredientId == 0)
                {
                    var ingredient = new IngredientDbModel()
                    {
                        IngredientName = ingredientName
                    };
                    var x = context.Ingredients.Add(ingredient);
                    context.SaveChanges();
                    ingredientId = FindIngredient(ingredientName);
                }
                return ingredientId;
            }
        }

        /// <summary>
        /// Return Existing Ingredient id
        /// </summary>
        /// <param name="ingredientName">ingredient name in string like "carrot"</param>
        /// <returns>ingredient id</returns>
        public static int FindIngredient(string ingredientName)
        {
            using (var context = new MyDbContext())
            {
                int ingredientId = context.Ingredients.Where(x => x.IngredientName == ingredientName)
                .Select(x => x.IngredientId).FirstOrDefault();
                return ingredientId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientsIds">List of ingredients ids</param>
        /// <returns>List of ingredients names</returns>
        public static List<string> GetIngredientsName(List<int> ingredientsIds)
        {
            List<string> ingredientsNames = new List<string>();

            using (var context = new MyDbContext())
            {
                foreach (var item in ingredientsIds)
                {
                    ingredientsNames.Add(context.Ingredients.Where(x => x.IngredientId == item).Select(x => x.IngredientName).Single());
                }
                return ingredientsNames;

            }
        }

    }
}
