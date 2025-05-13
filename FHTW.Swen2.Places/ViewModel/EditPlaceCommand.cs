using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class EditPlaceCommand: ICommand
    {
        public EditPlaceCommand(MainViewModel parent)
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
            Parent.PlaceDetails.Locked = false;
            Parent.ShowPlace();

            Parent.Button1 = new(true, "Save", new SavePlaceCommand(Parent));
            Parent.Button2 = new(true, "Cancel", new CancelEditPlaceCommand(Parent));
        }
    }
}
