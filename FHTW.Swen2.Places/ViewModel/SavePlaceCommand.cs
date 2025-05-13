using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class SavePlaceCommand: ICommand
    {
        public SavePlaceCommand(MainViewModel parent)
        {
            Parent = parent;
            Parent.PlaceDetails.PropertyChanged +=
                (sender, e) => { CanExecuteChanged?.Invoke(this, e); };
        }


        public MainViewModel Parent
        {
            get;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return Parent.PlaceDetails.CanSave;
        }

        public void Execute(object? parameter)
        {
            Parent.PlaceDetails.Save();
            Parent.Button1 = new(true, "New", new NewPlaceCommand(Parent));
            Parent.Button2 = new(true, "Edit", new EditPlaceCommand(Parent));
            Parent.Button3 = new(true, "Delete", new DeletePlaceCommand(Parent));
        }
    }
}
