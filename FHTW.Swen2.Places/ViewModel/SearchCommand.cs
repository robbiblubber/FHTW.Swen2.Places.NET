using System;
using System.Windows.Input;

using FHTW.Swen2.Places.Model;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class implements a command for the search button.</summary>
    public sealed class SearchCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
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
            return !string.IsNullOrWhiteSpace(Parent.SearchExpression);
        }


        /// <summary>Executes the command with the given parameter.</summary>
        /// <param name="parameter">Parameter.</param>
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
