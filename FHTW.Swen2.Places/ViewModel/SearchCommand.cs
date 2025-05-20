using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using FHTW.Swen2.Places.Model;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class SearchCommand: ICommand
    {
        public SearchCommand(MainViewModel parent) 
        { 
            Parent = parent;

            Parent.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == nameof(Parent.SearchExpression))
                {
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                }
            };
        }


        public MainViewModel Parent 
        {
            get;
        }


        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Parent.SearchExpression);
        }


        public void Execute(object? parameter)
        {
            Parent.SearchResults.Items.Clear();

            using DataContext db = new();
            foreach(Place i in db.SearchPlaces(Parent.SearchExpression))
            {
                Parent.SearchResults.Items.Add(new(Parent, i));
            }

            Parent.ShowSearchResults();

            Parent.Button1 = Parent.CommonButtons.NEW;
            Parent.Button2 = Parent.Button3 = Parent.CommonButtons.EMPTY;
        }
    }
}
