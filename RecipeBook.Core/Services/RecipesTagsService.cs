﻿using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Services
{
    public static class RecipesTagsService
    {
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
    }
}