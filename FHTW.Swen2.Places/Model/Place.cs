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
        private readonly ILazyLoader? _Lazy;

        private ICollection<Story>? _Stories;

        private ILocation? _BackingLocation;


        public Place()
        {}


        private Place(ILazyLoader? lazy)
        {
            _Lazy = lazy;
        }


        [Key][Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get; private set;
        }


        [Column("NAME")]
        public string Name
        {
            get; set;
        } = string.Empty;


        [Column("DESCRIPTION")]
        public string Description
        {
            get; set;
        } = string.Empty;


        [NotMapped]
        public ILocation? Location
        {
            get { return _BackingLocation; }
            set { _BackingLocation = value; }
        }


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
