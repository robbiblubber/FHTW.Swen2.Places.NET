using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FHTW.Swen2.Places.Model;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class SearchResultViewModel
    {
        private SelectSearchResultCommand _SearchCommand;



        public SearchResultViewModel(MainViewModel parent, Place place)
        {
            Parent = parent;
            Place = place;
        }


        public MainViewModel Parent
        {
            get;
        }


        public Place Place
        {
            get; 
        }


        public string Name
        {
            get { return Place.Name; }
        }


        public string Description
        {
            get { return Place.Description; }
        }


        public SelectSearchResultCommand SelectCommand
        {
            get
            {
                if(_SearchCommand is null) { _SearchCommand = new(Parent); }
                return _SearchCommand;
            }
        }
    }
}
