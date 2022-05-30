using RecipeBook.Core.Core;
using RecipeBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook.Core.ViewModels
{
    class RecipeViewModel: ObservableObject
    {
        public ObservableCollection<RecipeModel> recipes = new ObservableCollection<RecipeModel>();

        public ICommand ShowRecipesCommand { get; }

        public RecipeViewModel()
        {
            ShowRecipesCommand = new ShowRecipesCommand(this);
        }
    }
}
