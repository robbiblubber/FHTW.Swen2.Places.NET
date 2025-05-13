using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class CancelEditPlaceCommand: ICommand
    {
        public CancelEditPlaceCommand(MainViewModel parent)
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
            if(Parent.PlaceDetails.Place?.Exists ?? false)
            {
                Parent.Button1 = new(true, "New", new NewPlaceCommand(Parent));
                Parent.Button2 = new(true, "Edit", new EditPlaceCommand(Parent));
                Parent.Button3 = new(true, "Delete", new DeletePlaceCommand(Parent));
            }
            else
            {
                Parent.PlaceDetails.Place = null;
                Parent.Button1 = new(true, "New", new NewPlaceCommand(Parent));
                Parent.Button2 = Parent.Button3 = ButtonViewModel.EMPTY;
                Parent.ShowNothing();
            }

            Parent.PlaceDetails.Reset();
        }
    }
}
