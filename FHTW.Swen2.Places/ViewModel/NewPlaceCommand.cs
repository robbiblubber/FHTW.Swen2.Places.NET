using System;
using System.Windows.Input;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class NewPlaceCommand: ICommand
    {
        public NewPlaceCommand(MainViewModel parent)
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
            return Parent.PlaceDetails.Locked;
        }


        public void Execute(object? parameter)
        {
            Parent.PlaceDetails.Place = new();
            Parent.PlaceDetails.Locked = false;
            Parent.ShowPlace();

            Parent.Button1 = new(true, "Save", new SavePlaceCommand(Parent));
            Parent.Button2 = new(true, "Cancel", new CancelEditPlaceCommand(Parent));
        }
    }
}
