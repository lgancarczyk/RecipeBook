using RecipeBook.Core.Core;
using RecipeBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace RecipeBook.Core.ViewModels
{
    class RecipeViewModel: ObservableObject
    {
        public ObservableCollection<RecipeModel> recipes { get; set; } = new ObservableCollection<RecipeModel>();


        public ICommand ShowRecipesCommand { get; }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));


                //if (!IsStrEmpty(SearchText))
                //{
                //    Trace.WriteLine("Error like that");
                //}
            }
        }

        private bool IsStrEmpty(object tags)
        {
            throw new NotImplementedException();
        }

        public RecipeViewModel()
        {
            ShowRecipesCommand = new ShowRecipesCommand(this);
            ShowRecipesCommand.Execute(this);
            CollectionViewSource.GetDefaultView(this.recipes).Refresh();
        }
    }
}
