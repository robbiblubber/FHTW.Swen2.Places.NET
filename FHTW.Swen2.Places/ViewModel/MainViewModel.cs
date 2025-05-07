using System;
using System.ComponentModel;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides the main view model for the application.</summary>
    public sealed class MainViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
