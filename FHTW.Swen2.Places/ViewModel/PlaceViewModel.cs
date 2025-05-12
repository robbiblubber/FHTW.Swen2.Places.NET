using System;
using System.ComponentModel;
using System.Windows;

using FHTW.Swen2.Places.Model;



namespace FHTW.Swen2.Places.ViewModel
{
    public class PlaceViewModel: INotifyPropertyChanged
    {
        private Place? _Place;

        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private string _Latitude = string.Empty;
        private string _Longitude = string.Empty;
        private string _Street = string.Empty;
        private string _Code = string.Empty;
        private string _Town = string.Empty;
        private string _Country = string.Empty;

        private bool _AddressShowing;

        private bool _Locked = true;



        public PlaceViewModel(MainViewModel parent) 
        {
            Parent = parent;
        }

        public MainViewModel Parent
        {
            get;
        }


        public Place? Place
        {
            get { return _Place; }
            set
            {
                _Place = value;
                
                Reset();
            }
        }


        public bool Locked
        {
            get { return _Locked; }
            set
            {
                if(_Locked != value)
                {
                    _Locked = value;
                    PropertyChanged?.Invoke(this, new(nameof(Locked)));
                    PropertyChanged?.Invoke(this, new(nameof(TextBoxColor)));
                    PropertyChanged?.Invoke(this, new(nameof(SwitchLinkVisibility)));
                }
            }
        }


        public bool AddressShowing
        {
            get { return _AddressShowing; }
            set
            {
                if(_AddressShowing != value)
                {
                    _AddressShowing = value;
                    PropertyChanged?.Invoke(this, new(nameof(AddressShowing)));
                    PropertyChanged?.Invoke(this, new(nameof(AddressVisibility)));
                    PropertyChanged?.Invoke(this, new(nameof(CoordinatesVisibility)));
                }
            }
        }


        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name != value)
                { 
                    _Name = value;
                    PropertyChanged?.Invoke(this, new(nameof(Name)));
                }
            }
        }


        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description != value)
                { 
                    _Description = value;
                    PropertyChanged?.Invoke(this, new(nameof(Description)));
                }
            }
        }


        public string Latitude
        {
            get { return _Latitude; }
            set
            {
                if(_Latitude != value)
                { 
                    _Latitude = value;
                    PropertyChanged?.Invoke(this, new(nameof(Latitude)));
                }
            }
        }


        public string Longitude
        {
            get { return _Longitude; }
            set
            {
                if(_Longitude != value)
                { 
                    _Longitude = value;
                    PropertyChanged?.Invoke(this, new(nameof(Longitude)));
                }
            }
        }


        public string Street
        {
            get { return _Street; }
            set
            {
                if(_Street != value)
                { 
                    _Street = value;
                    PropertyChanged?.Invoke(this, new(nameof(Street)));
                }
            }
        }


        public string Code
        {
            get { return _Code; }
            set
            {
                if(_Code != value)
                { 
                    _Code = value;
                    PropertyChanged?.Invoke(this, new(nameof(Code)));
                }
            }
        }


        public string Town
        {
            get { return _Town; }
            set
            {
                if(_Town != value)
                { 
                    _Town = value;
                    PropertyChanged?.Invoke(this, new(nameof(Town)));
                }
            }
        }


        public string Country
        {
            get { return _Country; }
            set
            {
                if(_Country != value)
                { 
                    _Country = value;
                    PropertyChanged?.Invoke(this, new(nameof(Country)));
                }
            }
        }


        public string TextBoxColor
        {
            get
            {
                System.Drawing.Color col = System.Drawing.SystemColors.Window;
                return _Locked ? $"#{col.R:X2}{col.G:X2}{col.B:X2}" : "#f8fff8";
            }
        }


        public Visibility SwitchLinkVisibility
        {
            get { return _Locked ? Visibility.Hidden : Visibility.Visible; }
        }


        public Visibility AddressVisibility
        {
            get { return AddressShowing ? Visibility.Visible : Visibility.Hidden; }
        }


        public Visibility CoordinatesVisibility
        {
            get { return AddressShowing ? Visibility.Hidden : Visibility.Visible; }
        }


        public event PropertyChangedEventHandler? PropertyChanged;


        public void Reset()
        {
            Locked = true;

            Name = Place?.Name ?? string.Empty;
            Description = Place?.Description ?? string.Empty;

            if(Place?.Location is Address adr)
            {
                Street = adr.Street;
                Code = adr.Code;
                Town = adr.Town;
                Country = adr.Country;

                Latitude = Longitude = string.Empty;
                AddressShowing = true;
            }
            else if(Place?.Location is Coordinates coo)
            {
                Latitude = coo.Latitude.ToString();
                Longitude = coo.Longitude.ToString();

                Street = Code = Town = Country = string.Empty;
                AddressShowing = false;
            }
            else
            {
                Latitude = Longitude = 
                Street = Code = Town = Country = string.Empty;
                AddressShowing = false;
            }
        }
    }
}
