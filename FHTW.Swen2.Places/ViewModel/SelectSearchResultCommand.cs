using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using FHTW.Swen2.Places.Model;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class SelectSearchResultCommand: ICommand
    {
        public SelectSearchResultCommand(MainViewModel parent) 
        {
            Parent = parent;
        }


        public MainViewModel Parent 
        { 
            get;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Parent.PlaceDetails.Place = Parent.SearchResults.SelectedResult.Place;

            Parent.ShowPlace();
            Parent.Button1 = Parent.CommonButtons.NEW;
            Parent.Button2 = Parent.CommonButtons.EDIT;
            Parent.Button3 = Parent.CommonButtons.DELETE;
        }
    }
}
