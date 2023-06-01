using FHTW.Swen2.Places.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FHTW.Swen2.Places.Client
{
    /// <summary>This class implements a view model for the place details.</summary>
    public class PlaceDetailViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Place currently displayed.</summary>
        private Place? _Place;

        /// <summary>Parent view model.</summary>
        internal readonly MainViewModel _Parent;

        private string _Name;
        private string _Description;
        private string _Latitude;
        private string _Longitude;
        private string _Street;
        private string _Code;
        private string _Town;
        private string _Country;

        private bool _AddressShowing;

        private bool _Locked = true;
        private int _EditingBorders = 0;
        private Visibility _SwitchLinkVisibility = Visibility.Hidden;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        internal PlaceDetailViewModel(MainViewModel parent)
        {
            _Parent = parent;
            SwitchLocation = new(this);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                           //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name != value ) 
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


        public bool Locked
        {
            get { return _Locked; }
            set
            {
                if(_Locked != value)
                {
                    _Locked = value;
                    PropertyChanged?.Invoke(this, new(nameof(Locked)));
                }
            }
        }


        public int EditingBorders
        {
            get { return _EditingBorders; }
            set
            {
                if(_EditingBorders != value)
                {
                    _EditingBorders = value;
                    PropertyChanged?.Invoke(this, new(nameof(EditingBorders)));
                }
            }
        }


        public Visibility SwitchLinkVisibility
        {
            get { return _SwitchLinkVisibility; }
            set
            {
                if(_SwitchLinkVisibility != value)
                {
                    _SwitchLinkVisibility = value;
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


        public Visibility AddressVisibility
        {
            get { return (AddressShowing ? Visibility.Visible : Visibility.Hidden); }
        }


        public Visibility CoordinatesVisibility
        {
            get { return (AddressShowing ? Visibility.Hidden: Visibility.Visible); }
        }


        public SwitchLocationCommand SwitchLocation
        {
            get; private set;
        }


        public ObservableCollection<StoryListData> Stories
        {
            get; private set;
        } = new();



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public methods                                                                                           //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Shows a place.</summary>
        /// <param name="place">Place.</param>
        public void Show(Place place)
        {
            _Place = place;

            Stories.Clear();
            foreach(Story i in _Place.Stories)
            {
                Stories.Add(new(this, i));
            }

            ResetData();

            PropertyChanged?.Invoke(this, new(nameof(AddressVisibility)));
            PropertyChanged?.Invoke(this, new(nameof(CoordinatesVisibility)));

            // TODO: _Parent.ShowPlace();
        }


        public void ResetData()
        {
            if(_Place == null) return;

            Name = _Place.Name;
            Description = _Place.Description;

            AddressShowing = true;

            if(_Place.Location is Address)
            {
                Street = ((Address) _Place.Location).Street;
                Code = ((Address) _Place.Location).Code;
                Town = ((Address) _Place.Location).Town;
                Country = ((Address) _Place.Location).Country;
            }
            else if(_Place.Location is Coordinates) 
            { 
                Latitude = ((Coordinates) _Place.Location).Latitude.ToString();
                Longitude = ((Coordinates) _Place.Location).Longitude.ToString();

                AddressShowing = true;
            }

            _Parent.Button1 = new(true, "Edit", new EditPlaceCommand(this));
        }


        public bool CanSave()
        {
            return true;
        }


        public void Save()
        {}


        public void StartEdit()
        {
            Locked = false;
            EditingBorders = 1;
            SwitchLinkVisibility = Visibility.Visible;
        }


        public void CancelEdit()
        {
            Locked = true;
            EditingBorders = 0;
            SwitchLinkVisibility = Visibility.Hidden;

            ResetData();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
