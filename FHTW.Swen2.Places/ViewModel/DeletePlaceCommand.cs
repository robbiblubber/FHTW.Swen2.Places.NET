using System;
using System.Windows;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class implements a command for deleting a place.</summary>
    public sealed class DeletePlaceCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        public DeletePlaceCommand(MainViewModel parent)
        {
            Parent = parent;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the parent view model.</summary>
        public MainViewModel Parent
        {
            get;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] ICommand                                                                                     //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>This event occurs when the value returned by <see cref="CanExecute(object?)"/> has changed.</summary>
        public event EventHandler? CanExecuteChanged;


        /// <summary>Gets if the command can be executed with the given parameter.</summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Returns TRUE if the command can execute, otherwise returns FALSE.</returns>
        public bool CanExecute(object? parameter)
        {
            return true;
        }


        /// <summary>Executes the command with the given parameter.</summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object? parameter)
        {
            if(MessageBox.Show("Do you really want to delete this place\n" +
                          "(the place will not be physically destroyed)?", "Delete",
                          MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Parent.PlaceDetails.Delete();

                Parent.Button1 = Parent.CommonButtons.NEW;
                Parent.Button2 = Parent.Button3 = Parent.CommonButtons.EMPTY;

                Parent.ShowNothing();
            }
        }
    }
}
