using System;
using System.ComponentModel;
using System.Windows;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides the main view model for the application.</summary>
    public sealed class MainViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Result box visiblility.</summary>
        private Visibility _ResultBoxVisibility = Visibility.Hidden;

        /// <summary>Place control visibility.</summary>
        private Visibility _PlaceControlVisibility = Visibility.Hidden;

        /// <summary>Search expression for search.</summary>
        private string _SearchExpression = string.Empty;

        /// <summary>View model for button 1.</summary>
        private ButtonViewModel _Button1;

        /// <summary>View model for button 2.</summary>
        private ButtonViewModel _Button2;

        /// <summary>View model for button 3.</summary>
        private ButtonViewModel _Button3;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        public MainViewModel() 
        {
            PlaceDetails = new(this);
            CommonButtons = new(this);
            SearchResults = new(this);

            SearchCommand = new(this);
            GeneratePlaceReportCommand = new(this);

            _Button1 = CommonButtons.NEW;
            _Button2 = _Button3 = CommonButtons.EMPTY;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the view model for the place details.</summary>
        public PlaceViewModel PlaceDetails
        {
            get;
        }


        /// <summary>Gets the search result view model.</summary>
        public SearchResultListViewModel SearchResults
        {
            get;
        }


        /// <summary>Gets or sets the visibility for the search result list view.</summary>
        public Visibility ResultBoxVisibility
        {
            get { return _ResultBoxVisibility; }
            set 
            {
                if(_ResultBoxVisibility != value)
                {
                    _ResultBoxVisibility = value;
                    PropertyChanged?.Invoke(this, new(nameof(ResultBoxVisibility)));
                }
            }
        }


        /// <summary>Gets or sets the visibility for the place details view.</summary>
        public Visibility PlaceControlVisibility
        {
            get { return _PlaceControlVisibility; }
            set 
            {
                if(_PlaceControlVisibility != value)
                {
                    _PlaceControlVisibility = value;
                    PropertyChanged?.Invoke(this, new(nameof(PlaceControlVisibility)));
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
                    PropertyChanged?.Invoke(this, new(nameof(SearchExpression)));
                }
            }
        }


        /// <summary>Gets or sets the view model for button 1.</summary>
        public ButtonViewModel Button1
        {
            get { return _Button1; }
            set 
            {
                if(_Button1 != value)
                {
                    _Button1 = value;
                    PropertyChanged?.Invoke(this, new(nameof(Button1)));
                }
            }
        }


        /// <summary>Gets or sets the view model for button 2.</summary>
        public ButtonViewModel Button2
        {
            get { return _Button2; }
            set 
            {
                if(_Button2 != value)
                {
                    _Button2 = value;
                    PropertyChanged?.Invoke(this, new(nameof(Button2)));
                }
            }
        }


        /// <summary>Gets or sets the view model for button 3.</summary>
        public ButtonViewModel Button3
        {
            get { return _Button3; }
            set 
            {
                if(_Button3 != value)
                {
                    _Button3 = value;
                    PropertyChanged?.Invoke(this, new(nameof(Button3)));
                }
            }
        }


        /// <summary>Gets the search command.</summary>
        public SearchCommand SearchCommand
        {
            get;
        }


        /// <summary>Gets the generate place report command.</summary>
        public GeneratePlaceReportCommand GeneratePlaceReportCommand
        {
            get;
        }


        /// <summary>Gets the common buttons view models.</summary>
        public CommonButtonViewModel CommonButtons
        {
            get;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public methods                                                                                           //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Shows no control in the main window.</summary>
        public void ShowNothing()
        {
            ResultBoxVisibility = PlaceControlVisibility = Visibility.Hidden;
        }


        /// <summary>Shows the search result box in the main window.</summary>
        public void ShowSearchResults()
        {
            ResultBoxVisibility = Visibility.Visible;
            PlaceControlVisibility = Visibility.Hidden;
        }


        /// <summary>Shows the place details control in the main window.</summary>
        public void ShowPlace()
        {
            PlaceControlVisibility = Visibility.Visible;
            ResultBoxVisibility = Visibility.Hidden;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
