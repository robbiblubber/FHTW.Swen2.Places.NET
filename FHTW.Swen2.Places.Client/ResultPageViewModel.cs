using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHTW.Swen2.Places.Client
{
    public class ResultPageViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Parent main view model.</summary>
        internal MainViewModel _Parent;

        /// <summary>Result index.</summary>
        private int _ResultIndex = -1;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        internal ResultPageViewModel(MainViewModel parent)
        {
            _Parent = parent;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets the search results.</summary>
        public ObservableCollection<SearchResultData> SearchResults
        {
            get;
        } = new();


        /// <summary>Gets or sets the result index.</summary>
        public int ResultIndex
        {
            get { return _ResultIndex; }
            set
            {
                if(_ResultIndex != value ) 
                {
                    _ResultIndex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultIndex)));
                }
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
