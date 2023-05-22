using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FHTW.Swen2.Places.Client
{
    /// <summary>This class implements the main view model for this application.</summary>
    public class MainViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Result box visibility flag.</summary>
        private Visibility _ResultBoxVisibility = Visibility.Hidden;

        /// <summary>Search expression.</summary>
        private string _SearchExpression = "";



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        public MainViewModel() 
        {
            ResultPage = new(this);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the result page view model.</summary>
        public ResultPageViewModel ResultPage
        {
            get; private set;
        }


        /// <summary>Gets or sets the visibility for the result box.</summary>
        public Visibility ResultBoxVisibility
        {
            get { return _ResultBoxVisibility; }
            set 
            {
                if(_ResultBoxVisibility != value)
                {
                    _ResultBoxVisibility = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultBoxVisibility)));
                }
            }
        }


        /// <summary>Gets or sets the search expression string.</summary>
        public string SearchExpression
        {
            get { return _SearchExpression; }
            set
            {
                if(_SearchExpression != value)
                {
                    _SearchExpression = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchExpression)));
                }
            }
        }
    }
}
