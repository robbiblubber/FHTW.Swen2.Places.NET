using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents a place.</summary>
    [Table("PLACES")][PrimaryKey("ID")]
    public sealed class Place
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Lazy loader.</summary>
        private readonly ILazyLoader? _Lazy;

        /// <summary>Stories for this instance.</summary>
        private ICollection<Story>? _Stories;

        /// <summary>Location.</summary>
        private ILocation? _BackingLocation;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        public Place()
        {}


        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="lazy">Lazy loader.</param>
        private Place(ILazyLoader? lazy)
        {
            _Lazy = lazy;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the place ID.</summary>
        [Key][Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get; private set;
        }


        /// <summary>Gets or sets the place name.</summary>
        [Column("NAME")]
        public string Name
        {
            get; set;
        } = string.Empty;


        /// <summary>Gets or sets the place description.</summary>
        [Column("DESCRIPTION")]
        public string Description
        {
            get; set;
        } = string.Empty;


        /// <summary>Gets or sets the location of the place.</summary>
        [NotMapped]
        public ILocation? Location
        {
            get { return _BackingLocation; }
            set { _BackingLocation = value; }
        }


        /// <summary>Gets a collection of stories about the place.</summary>
        public ICollection<Story> Stories
        {
            get
            {
                if(_Lazy is null)
                {
                    if(_Stories is null) { _Stories = new List<Story>(); }
                    return _Stories;
                }

                return _Lazy.Load(this, ref _Stories) ?? (_Stories = new List<Story>());
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private properties                                                                                       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets or sets a string representing the location of the place.</summary>
        [Column("LOCATION")]
        internal string _Location
        {
            get
            {
                if(Location is Coordinates coo)
                {
                    return "cood://" + JsonSerializer.Serialize(coo);
                }
                if(Location is Address adr)
                {
                    return "addr://" + JsonSerializer.Serialize(adr);
                }

                return string.Empty;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                { 
                    Location = null; 
                }
                else if(value.StartsWith("cood://"))
                {
                    Location = JsonSerializer.Deserialize<Coordinates>(value[7..]);
                }
                else if(value.StartsWith("addr://"))
                {
                    Location = JsonSerializer.Deserialize<Address>(value[7..]);
                }
            }
        }
    }
}
