using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class DeletePlaceCommand: ICommand
    {
        public DeletePlaceCommand(MainViewModel parent)
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
            if(MessageBox.Show("Do you really want to delete this place\n" +
                          "(the place will not be physically destroyed)?", "Delete",
                          MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Parent.PlaceDetails.Delete();

                Parent.Button1 = new(true, "New", new NewPlaceCommand(Parent));
                Parent.Button2 = Parent.Button3 = ButtonViewModel.EMPTY;

                Parent.ShowNothing();
            }
        }
    }
}
