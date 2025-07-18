﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

using FHTW.Swen2.Places.Model;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class implements the view model for the place details control.</summary>
    public sealed class PlaceViewModel: INotifyPropertyChanged
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private constants                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Map template.</summary>
        private static readonly string _MAP_TEMPLATE = _GetMapTemplate();

        /// <summary>Empty HTML document.</summary>
        private static readonly string _EMPTY = "<!DOCTYPE html><head/><body/></html";



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Place shown.</summary>
        private Place? _Place;

        /// <summary>Place name.</summary>
        private string _Name = string.Empty;

        /// <summary>Place description.</summary>
        private string _Description = string.Empty;

        /// <summary>Coordinates latitude.</summary>
        private string _Latitude = string.Empty;

        /// <summary>Coordinates longitude.</summary>
        private string _Longitude = string.Empty;

        /// <summary>Address street.</summary>
        private string _Street = string.Empty;

        /// <summary>Address postal code.</summary>
        private string _Code = string.Empty;

        /// <summary>Address town.</summary>
        private string _Town = string.Empty;

        /// <summary>Address country.</summary>
        private string _Country = string.Empty;

        /// <summary>Flag indicating if the address (instead of coordinates) is shown.</summary>
        private bool _AddressShowing;

        /// <summary>Flag indicating if the control is locked (read-only).</summary>
        private bool _Locked = true;

        /// <summary>Toggle location command.</summary>
        private ToggleLocationCommand? _ToggleLocationCommand = null;

        /// <summary>Location valid flag.</summary>
        private bool _LocationValid = false;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent main view model.</param>
        public PlaceViewModel(MainViewModel parent) 
        {
            Parent = parent;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private static methods                                                                                   //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Reads the map template.</summary>
        /// <returns>Map template source.</returns>
        private static string _GetMapTemplate()
        {
            string fileName = AppContext.BaseDirectory + "leaflet.html";
            if(File.Exists(fileName)) { return File.ReadAllText(fileName); }

            return _EMPTY;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the parent main view model.</summary>
        public MainViewModel Parent
        {
            get;
        }


        /// <summary>Gets or sets the place shown in the control.</summary>
        public Place? Place
        {
            get { return _Place; }
            set
            {
                _Place = value;

                Stories.Clear();
                if(_Place is not null)
                {
                    foreach(Story i in _Place.Stories) { Stories.Add(new(Parent, i)); }
                }

                Reset();
            }
        }


        /// <summary>Gets the story view models in this view model.</summary>
        public ObservableCollection<StoryViewModel> Stories
        {
            get;
        } = new();


        /// <summary>Gets the toggle location view command.</summary>
        public ToggleLocationCommand ToggleLocationCommand
        {
            get
            {
                if(_ToggleLocationCommand is null) { _ToggleLocationCommand = new(Parent); }
                return _ToggleLocationCommand;
            }
        }


        /// <summary>Gets or sets if the control is locked (read-only).</summary>
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


        /// <summary>Gets or sets if the address is shown instead of the coordinates.</summary>
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


        /// <summary>Gets or sets the place name.</summary>
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


        /// <summary>Gets or sets the place description.</summary>
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


        /// <summary>Gets or sets the place latitude.</summary>
        public string Latitude
        {
            get { return _Latitude; }
            set
            {
                if(_Latitude != value)
                { 
                    _Latitude = value;
                    PropertyChanged?.Invoke(this, new(nameof(Latitude)));
                    PropertyChanged?.Invoke(this, new(nameof(MapSource)));
                }
            }
        }


        /// <summary>Gets or sets the place longitude.</summary>
        public string Longitude
        {
            get { return _Longitude; }
            set
            {
                if(_Longitude != value)
                { 
                    _Longitude = value;
                    PropertyChanged?.Invoke(this, new(nameof(Longitude)));
                    PropertyChanged?.Invoke(this, new(nameof(MapSource)));
                }
            }
        }


        /// <summary>Gets or sets the street of the address.</summary>
        public string Street
        {
            get { return _Street; }
            set
            {
                if(_Street != value)
                { 
                    _Street = value;
                    PropertyChanged?.Invoke(this, new(nameof(Street)));
                    PropertyChanged?.Invoke(this, new(nameof(MapSource)));
                }
            }
        }


        /// <summary>Gets or sets the postal code of the address.</summary>
        public string Code
        {
            get { return _Code; }
            set
            {
                if(_Code != value)
                { 
                    _Code = value;
                    PropertyChanged?.Invoke(this, new(nameof(Code)));
                    PropertyChanged?.Invoke(this, new(nameof(MapSource)));
                }
            }
        }


        /// <summary>Gets or sets the town of the address.</summary>
        public string Town
        {
            get { return _Town; }
            set
            {
                if(_Town != value)
                { 
                    _Town = value;
                    PropertyChanged?.Invoke(this, new(nameof(Town)));
                    PropertyChanged?.Invoke(this, new(nameof(MapSource)));
                }
            }
        }


        /// <summary>Gets or sets the city of the address.</summary>
        public string Country
        {
            get { return _Country; }
            set
            {
                if(_Country != value)
                { 
                    _Country = value;
                    PropertyChanged?.Invoke(this, new(nameof(Country)));
                    PropertyChanged?.Invoke(this, new(nameof(MapSource)));
                }
            }
        }


        /// <summary>Gets the map source URI.</summary>
        public Uri MapSource
        {
            get
            {
                string src;
                Coordinates? c = AddressShowing ?
                                 MapResolver.Resolve(Street, Code, Town, Country) :
                                 MapResolver.Resolve(Latitude, Longitude);

                if(c is null)
                {
                    _LocationValid = false;
                    src = _EMPTY;
                }
                else
                {
                    _LocationValid = true;
                    src = _MAP_TEMPLATE
                          .Replace("$lat", c.Latitude.ToString().Replace(',', '.'))
                          .Replace("$lng", c.Longitude.ToString().Replace(',', '.'));
                }

                PropertyChanged?.Invoke(this, new(nameof(CanSave)));

                return new($"data:text/html;base64,{Convert.ToBase64String(Encoding.UTF8.GetBytes(src))}");
            }
        }

        /// <summary>Gets the backgroud color of the text boxes in the control.</summary>
        /// <remarks>The text boxes will have a white (Window) background in view mode, and a green background in edit mode.</remarks>
        public string TextBoxColor
        {
            get
            {
                System.Drawing.Color col = System.Drawing.SystemColors.Window;
                return _Locked ? $"#{col.R:X2}{col.G:X2}{col.B:X2}" : "#f8fff8";
            }
        }


        /// <summary>Gets the visibility of the switch link.</summary>
        public Visibility SwitchLinkVisibility
        {
            get { return _Locked ? Visibility.Hidden : Visibility.Visible; }
        }


        /// <summary>Gets the visibility of the address fields.</summary>
        public Visibility AddressVisibility
        {
            get { return AddressShowing ? Visibility.Visible : Visibility.Hidden; }
        }


        /// <summary>Gets the visibility of the coordinates fields.</summary>
        public Visibility CoordinatesVisibility
        {
            get { return AddressShowing ? Visibility.Hidden : Visibility.Visible; }
        }


        /// <summary>Gets if the place can be saved.</summary>
        public bool CanSave
        {
            get
            {
                if(string.IsNullOrWhiteSpace(Name)) return false;

                return _LocationValid;
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public methods                                                                                           //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Resets the control contents.</summary>
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


        /// <summary>Saves the changes to the place.</summary>
        public void Save()
        {
            if(Place is null) return;

            Locked = true;

            Place.Name = Name;
            Place.Description = Description;

            if(AddressShowing)
            {
                Place.Location = new Address(Code, Street, Town, Country);
            }
            else
            {
                Place.Location = new Coordinates(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
            }

            Place.Save();
        }


        /// <summary>Deletes the place.</summary>
        public void Delete()
        {
            Place?.Delete();
            Place = null;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] INotifyPropertyChanged                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Occurs when a property has changed.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
