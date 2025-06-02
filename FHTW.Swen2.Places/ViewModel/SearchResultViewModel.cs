using System;

using FHTW.Swen2.Places.Model;

namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides a view model for a single search result.</summary>
    public sealed class SearchResultViewModel
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private static members                                                                                   //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Select command.</summary>
        private static SelectSearchResultCommand? _SelectCommand = null;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        /// <param name="place">Search result place instance.</param>
        public SearchResultViewModel(MainViewModel parent, Place place)
        {
            Parent = parent;
            Place = place;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the parent view model.</summary>
        public MainViewModel Parent
        {
            get;
        }


        /// <summary>Gets the place represented by the search result.</summary>
        public Place Place
        {
            get; 
        }


        /// <summary>Gets the place name for the search result.</summary>
        public string Name
        {
            get { return Place.Name; }
        }


        /// <summary>Gets the place description for the search result.</summary>
        public string Description
        {
            get { return Place.Description; }
        }


        /// <summary>Gets the command used for selecting the search result.</summary>
        public SelectSearchResultCommand SelectCommand
        {
            get
            {
                if(_SelectCommand is null) { _SelectCommand = new(Parent); }
                return _SelectCommand;
            }
        }
    }
}
