using RecipeBook.Core.Models;
using RecipeBook.Core.Services;
using RecipeBook.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _recipeViewModel.recipes = GetAllFullRecipes();
            

            //_recipeViewModel.recipes ;
        }

        public ObservableCollection<RecipeModel> GetAllFullRecipes() 
        {
            ObservableCollection<RecipeModel> result = new ObservableCollection<RecipeModel>();

            var rawRecipes = RecipesService.GetAllRecipes();
            foreach (var rawRecipe in rawRecipes)
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

                result.Add(recipeModel);
            }

            return result;
        }
    }
}
