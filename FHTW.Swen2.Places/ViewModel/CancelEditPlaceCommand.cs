using System;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class implements a command for cancelling place editing.</summary>
    public sealed class CancelEditPlaceCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        public CancelEditPlaceCommand(MainViewModel parent)
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
            if(Parent.PlaceDetails.Place?.Exists ?? false)
            {
                Parent.Button1 = Parent.CommonButtons.NEW;
                Parent.Button2 = Parent.CommonButtons.EDIT;
                Parent.Button3 = Parent.CommonButtons.DELETE;
            }
            else
            {
                Parent.PlaceDetails.Place = null;
                Parent.Button1 = Parent.CommonButtons.NEW;
                Parent.Button2 = Parent.Button3 = Parent.CommonButtons.EMPTY;
                Parent.ShowNothing();
            }

            Parent.PlaceDetails.Reset();
        }
    }
}
