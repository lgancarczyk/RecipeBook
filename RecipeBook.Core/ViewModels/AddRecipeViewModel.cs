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
    class AddRecipeViewModel : ObservableObject
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
        private string _tags;
        public string Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
                OnPropertyChanged(nameof(Tags));


                if (!IsStrEmpty(Tags))
                {
                    Trace.WriteLine("Error like that");
                }
            }
        }
        private string _noOfPortions;
        public string NoOfPortions
        {
            get
            {
                return _noOfPortions;
            }
            set
            {
                _noOfPortions = value;
                OnPropertyChanged(nameof(NoOfPortions));


                if (!IsStrEmpty(NoOfPortions))
                {
                    Trace.WriteLine("Error like that");
                }
            }
        }

        private string _ingredients;
        public string Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));


                if (!IsStrEmpty(Ingredients))
                {
                    Trace.WriteLine("Error like that");
                }
            }
        }

        private string _prescription;
        public string Prescription
        {
            get
            {
                return _prescription;
            }
            set
            {
                _prescription = value;
                OnPropertyChanged(nameof(Prescription));


                if (!IsStrEmpty(Prescription))
                {
                    Trace.WriteLine("Error like that");
                }
            }
        }

        private bool IsStrEmpty(string str) => !string.IsNullOrEmpty(str);

        public AddRecipeViewModel()
        {
            AddRecipeCommand = new AddRecipeCommand(this);
        }


    }
}
