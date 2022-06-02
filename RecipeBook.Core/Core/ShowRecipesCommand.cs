using RecipeBook.Core.Database.DbModels;
using RecipeBook.Core.Models;
using RecipeBook.Core.Services;
using RecipeBook.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeBook.Core.Core
{
    class ShowRecipesCommand : CommandBase
    {

        private readonly RecipeViewModel _recipeViewModel;
        public ShowRecipesCommand( RecipeViewModel recipeViewModel)
        {
            _recipeViewModel = recipeViewModel;
        }

        /// <summary>
        /// Button click exucution. Adds to ViemModel`s 
        /// observablecollection Full Recipes (with tags and ingredients)
        /// </summary>
        /// <param name="parameter">viemModel</param>
        public override void Execute(object parameter)
        {
            List<RecipeModel> recipeList = new List<RecipeModel>();
            if (_recipeViewModel.SearchText == null || _recipeViewModel.SearchText ==String.Empty)
            {
                _recipeViewModel.recipes.Clear();
                foreach (var item in GetAllFullRecipes())
                {
                    _recipeViewModel.recipes.Add(item);
                }
            }
            
            else
            {
                _recipeViewModel.recipes.Clear();
                var recipesByTitle = GetFullRecipesByTitle(_recipeViewModel.SearchText);
                foreach (var item in recipesByTitle) 
                {
                    recipeList.Add(item); 
                }

                var recipesByTag = GetFullRecipesByTag(_recipeViewModel.SearchText);
                foreach (var item in recipesByTag) 
                {
                    recipeList.Add(item);
                }

                List<RecipeModel> distinctRecipe = recipeList
                  .GroupBy(p => p.RecipeId)
                  .Select(g => g.First())
                  .ToList();
                foreach (var recipe in distinctRecipe)
                {
                    _recipeViewModel.recipes.Add(recipe);
                }
            }
        }

        private List<RecipeModel> GetFullRecipesByTitle(string title)
        {
            var recipes = RecipesService.GetRecipesByTitle(title);
            return IterateThroughGetWholeRecipes(recipes);
        }

        private List<RecipeModel> GetFullRecipesByTag(string tag)
        {
            var tagId = TagsService.FindTag(tag);

            if (tagId != 0)
            {
                List<RecipeDbModel> rawRecipes = new List<RecipeDbModel>();
                var rawRecipesIds = RecipesTagsService.GetRecipesIds(tagId);
                foreach (var id in rawRecipesIds)
                {
                    var rawRecipe = RecipesService.GetRecipe(id);
                    rawRecipes.Add(rawRecipe);
                }
                return IterateThroughGetWholeRecipes(rawRecipes);
            }
            return new List<RecipeModel>();
        }

        private List<RecipeModel> GetAllFullRecipes() 
        {
            var rawRecipes = RecipesService.GetAllRecipes();
            return IterateThroughGetWholeRecipes(rawRecipes);
        }

        private List<RecipeModel> IterateThroughGetWholeRecipes(List<RecipeDbModel> rawRecipes) 
        {
            List<RecipeModel> result = new List<RecipeModel>();

            foreach (var rawRecipe in rawRecipes)
            {
                var recipe = GetWholeRecipe(rawRecipe);
                result.Add(recipe);
            }
            return result;
        }

        private RecipeModel GetWholeRecipe(RecipeDbModel rawRecipe) 
        {
            RecipeModel recipeModel = new RecipeModel();
            recipeModel.RecipeId = rawRecipe.RecipeId;
            recipeModel.Title = rawRecipe.Title;
            recipeModel.NoOfPortions = rawRecipe.NoOfPortions;
            recipeModel.Description = rawRecipe.Description;

            var tagsIdsList = RecipesTagsService.GetTagsIds(rawRecipe.RecipeId);
            recipeModel.Tags = String.Join(" ", TagsService.GetTagsName(tagsIdsList));

            var ingredientsIdsList = RecipesIngredientsService.GetIngredientsIds(rawRecipe.RecipeId);
            recipeModel.Ingredients = String.Join(" ", IngredientsService.GetIngredientsName(ingredientsIdsList));

            return recipeModel;
        }
    }
}
