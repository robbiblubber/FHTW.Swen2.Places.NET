using System;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides button view models for commonly used buttons in the view model.</summary>
    public sealed class CommonButtonViewModel
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        internal CommonButtonViewModel(MainViewModel parent) 
        {
            EMPTY  = new(false);
            NEW    = new(true, "New",    new NewPlaceCommand(parent));
            EDIT   = new(true, "Edit",   new EditPlaceCommand(parent));
            SAVE   = new(true, "Save",   new SavePlaceCommand(parent));
            DELETE = new(true, "Delete", new DeletePlaceCommand(parent));
            CANCEL = new(true, "Cancel", new CancelEditPlaceCommand(parent));
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets an empty button.</summary>
        public ButtonViewModel EMPTY
        {
            get;
        }


        /// <summary>Gets the "New" button.</summary>
        public ButtonViewModel NEW
        {
            get;
        }


        /// <summary>Gets the "Edit" button.</summary>
        public ButtonViewModel EDIT
        {
            get;
        }


        /// <summary>Gets the "Save" button.</summary>
        public ButtonViewModel SAVE
        {
            get;
        }


        /// <summary>Gets the "Delete" button.</summary>
        public ButtonViewModel DELETE
        {
            get;
        }


        /// <summary>Gets the "Cancel" button.</summary>
        public ButtonViewModel CANCEL
        {
            get;
        }
    }
}
