using System;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides a view model for the search result list.</summary>
    public sealed class SearchResultListViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Selected index.</summary>
        private int _SelectedIndex = -1;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        public SearchResultListViewModel(MainViewModel parent)
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


        /// <summary>Gets the search result items.</summary>
        public ObservableCollection<SearchResultViewModel> Items
        {
            get;
        } = new();


        /// <summary>Gets or sets the selected index in the search result list.</summary>
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if(_SelectedIndex != value)
                {
                    _SelectedIndex = value;
                    PropertyChanged?.Invoke(this, new(nameof(SelectedIndex)));
                }
            }
        }


        /// <summary>Gets the selected search result.</summary>
        public SearchResultViewModel SelectedResult
        {
            get { return Items[SelectedIndex]; }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
