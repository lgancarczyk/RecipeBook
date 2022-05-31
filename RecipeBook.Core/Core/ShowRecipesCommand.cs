using RecipeBook.Core.Database.DbModels;
using RecipeBook.Core.Models;
using RecipeBook.Core.Services;
using RecipeBook.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RecipeBook.Core.Core
{
    class ShowRecipesCommand : CommandBase
    {

        private readonly RecipeViewModel _recipeViewModel;
        public ShowRecipesCommand( RecipeViewModel recipeViewModel)
        {
            _recipeViewModel = recipeViewModel;
        }

        
        public override void Execute(object parameter)
        {
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
                    _recipeViewModel.recipes.Add(item);
                }

                var recipesByTag = GetFullRecipesByTag(_recipeViewModel.SearchText);
                foreach (var item in recipesByTag) 
                {
                    _recipeViewModel.recipes.Add(item);
                }
            }
        }

        public List<RecipeModel> GetFullRecipesByTitle(string title)
        {
            var recipes = RecipesService.GetRecipesByTitle(title);
            return IterateThroughGetWholeRecipes(recipes);
        }

        public List<RecipeModel> GetFullRecipesByTag(string tag)
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

        public List<RecipeModel> GetAllFullRecipes() 
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
