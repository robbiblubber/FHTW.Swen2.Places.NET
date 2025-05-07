using System;
using System.ComponentModel;
using System.Windows;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides the main view model for the application.</summary>
    public sealed class MainViewModel: INotifyPropertyChanged
    {
        private Visibility _ResultBoxVisibility = Visibility.Hidden;
        private Visibility _PlaceControlVisibility = Visibility.Hidden;

        private string _SearchExpression = string.Empty;

        private ButtonViewModel _Button1 = ButtonViewModel.EMPTY;
        private ButtonViewModel _Button2 = ButtonViewModel.EMPTY;
        private ButtonViewModel _Button3 = ButtonViewModel.EMPTY;


        public MainViewModel() 
        {
            PlaceDetails = new(this);
        }


        public PlaceViewModel PlaceDetails
        {
            get;
        }


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


        public void ShowNothing()
        {
            ResultBoxVisibility = PlaceControlVisibility = Visibility.Hidden;
        }


        public void ShowSearchResults()
        {
            ResultBoxVisibility = Visibility.Visible;
            PlaceControlVisibility = Visibility.Hidden;
        }


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
