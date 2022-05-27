using RecipeBook.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            Trace.WriteLine($"Its working {_addRecipeViewModel.Title}");
        }
    }
}
