using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

using Microsoft.EntityFrameworkCore;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents a place.</summary>
    [Table("PLACES")][PrimaryKey("ID")]
    public class Place
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Location.</summary>
        protected ILocation? _BackingLocation;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        public Place()
        {}



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
            get; set;
        } = new List<Story>();


        /// <summary>Gets if the place exists in the database.</summary>
        public bool Exists
        {
            get
            {
                using DataContext db = new();
                return db.Places.Contains(this);
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


        /// <summary>Saves the place to the database.</summary>
        public void Save()
        {
            using DataContext db = new();

            Place? me = db.Places.FirstOrDefault(m => m.ID == ID);
            if(me is null)
            {
                db.Places.Add(this);
            }
            else
            {
                me.Name = Name;
                me.Description = Description;
                me.Location = Location;
            }
            db.SaveChanges();
        }


        /// <summary>Deletes the place from the database.</summary>
        public void Delete()
        {
            using DataContext db = new();

            Place? me = db.Places.FirstOrDefault(m => m.ID == ID);
            if(me is not null)
            {
                db.Remove(me);
                db.SaveChanges();
            }
        }
    }
}
