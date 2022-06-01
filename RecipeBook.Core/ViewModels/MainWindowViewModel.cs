using RecipeBook.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.ViewModels
{
    class MainWindowViewModel: ObservableObject
    {
        public RelayCommand AddRecipeViewCommand { get; set; }
        public RelayCommand RecipeViewCommand { get; set; }

        public AddRecipeViewModel _addRecipeViewModel { get; set; }
        public RecipeViewModel _recipeViewModel { get; set; }


        /// <summary>
        /// Current Active UserControll
        /// </summary>
        public object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }

        }

        public MainWindowViewModel()
        {
            _addRecipeViewModel = new AddRecipeViewModel();
            _recipeViewModel = new RecipeViewModel();
            CurrentView = _recipeViewModel;

            AddRecipeViewCommand = new RelayCommand(o =>
            {
                CurrentView = _addRecipeViewModel;
            });
            RecipeViewCommand = new RelayCommand(o =>
            {
                CurrentView = _recipeViewModel;
            });
        }
    }
}
