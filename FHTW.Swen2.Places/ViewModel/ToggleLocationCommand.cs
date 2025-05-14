using System;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class ToggleLocationCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        public ToggleLocationCommand(MainViewModel parent)
        {
            Parent = parent;
            Parent.PlaceDetails.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == nameof(Parent.PlaceDetails.Locked))
                {
                    CanExecuteChanged?.Invoke(this, e);
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



        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !Parent.PlaceDetails.Locked;
        }


        public void Execute(object? parameter)
        {
            Parent.PlaceDetails.AddressShowing = !Parent.PlaceDetails.AddressShowing;
        }
    }
}
