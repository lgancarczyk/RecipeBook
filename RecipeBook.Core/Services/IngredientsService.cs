using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Services
{
    public static class IngredientsService
    {

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

        public static int FindIngredient(string ingredientName)
        {
            using (var context = new MyDbContext())
            {
                int ingredientId = context.Ingredients.Where(x => x.IngredientName == ingredientName)
                .Select(x => x.IngredientId).FirstOrDefault();
                return ingredientId;
            }
        }


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
