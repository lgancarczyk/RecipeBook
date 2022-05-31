using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using RecipeBook.Core.Services;
using RecipeBook.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeBook.Core.Core
{
    class AddRecipeCommand : CommandBase
    {
        private readonly AddRecipeViewModel _addRecipeViewModel;
        public AddRecipeCommand(AddRecipeViewModel addRecipeViewModel)
        {
            _addRecipeViewModel = addRecipeViewModel;
            _addRecipeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddRecipeViewModel.Title))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            //checks if all values are true 
            return !string.IsNullOrEmpty(_addRecipeViewModel.Title)
                && !string.IsNullOrEmpty(_addRecipeViewModel.Tags)
                && !string.IsNullOrEmpty(_addRecipeViewModel.NoOfPortions)
                && !string.IsNullOrEmpty(_addRecipeViewModel.Ingredients)
                && !string.IsNullOrEmpty(_addRecipeViewModel.Prescription)
                //&& IsNoOfPortionsInt()
                && base.CanExecute(parameter);
        }
        public bool IsNoOfPortionsInt() 
        {
            int number;
            
                bool isInt = int.TryParse(_addRecipeViewModel.NoOfPortions, out number);
            return isInt;
            
        }
        public override void Execute(object parameter)
        {
            try
            {
                var recipe = new RecipeDbModel()
                {
                    Title = _addRecipeViewModel.Title,
                    NoOfPortions = int.Parse(_addRecipeViewModel.NoOfPortions),
                    Description = _addRecipeViewModel.Prescription
                };
                var recipeId = RecipesService.AddRecipe(recipe);


                string[] rawTags = _addRecipeViewModel.Tags.Split(" ");
                List<string> tags = new List<string>();
                tags = rawTags.Distinct().ToList();


                foreach (var tag in tags)
                {
                    tag.Trim().ToLower();
                    if (tag != "")
                    {
                        var tagId = TagsService.AddTag(tag);

                        var isSuccess = RecipesTagsService.AddRecipesTagsRecord(recipeId, tagId);

                    }
                }

                string[] rawIngredients = _addRecipeViewModel.Ingredients.Split(" ");
                List<string> ingredients = new List<string>();
                ingredients = rawIngredients.Distinct().ToList();

                foreach (var ingredient in ingredients)
                {
                    ingredient.Trim().ToLower();
                    if (ingredient != "")
                    {
                        var ingredientId = IngredientsService.AddIngredient(ingredient);

                        var isSuccess = RecipesIngredientsService.AddRecipesIngredientsRecord(recipeId, ingredientId);

                    }
                }

                ClearInputs();


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearInputs() 
        {
            _addRecipeViewModel.Title = "";
            _addRecipeViewModel.Tags = "";
            _addRecipeViewModel.NoOfPortions = "";
            _addRecipeViewModel.Ingredients = "";
            _addRecipeViewModel.Prescription = "";

            var thread = new Thread(
                     () =>
                     {
                         MessageBox.Show("Recipe Added",
                                    "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

                     });
            thread.Start();
        }

    }
}
