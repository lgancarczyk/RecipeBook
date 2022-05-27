using Prism.Commands;
using RecipeBook.Core.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook.Core.ViewModels
{
    class AddRecipeViewModel: ObservableObject
    {
        public ICommand AddRecipeCommand { get; }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));


                if (!IsStrEmpty(Title))
                {
                    Trace.WriteLine("Error like that");
                }

                //OnPropertyChanged(nameof(CanCreateReservation));
            }
        }

        private bool IsStrEmpty(string str) => !string.IsNullOrEmpty(str);

        public AddRecipeViewModel()
        {
            AddRecipeCommand = new AddRecipeCommand(this);
        }

        
    }
}
