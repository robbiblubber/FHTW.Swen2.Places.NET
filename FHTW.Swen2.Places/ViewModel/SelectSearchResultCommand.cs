using System;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class implements a command for selecting a search result.</summary>
    public sealed class SelectSearchResultCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        public SelectSearchResultCommand(MainViewModel parent) 
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
            Parent.PlaceDetails.Place = Parent.SearchResults.SelectedResult.Place;

            Parent.ShowPlace();
            Parent.Button1 = Parent.CommonButtons.NEW;
            Parent.Button2 = Parent.CommonButtons.EDIT;
            Parent.Button3 = Parent.CommonButtons.DELETE;
        }
    }
}
