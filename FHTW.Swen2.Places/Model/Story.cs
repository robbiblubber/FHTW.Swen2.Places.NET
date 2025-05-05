using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents a story for a place.</summary>
    [Table("STORIES")][PrimaryKey("ID")]
    public class Story
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="place">Place.</param>
        public Story(Place place) 
        {
            Place = place;
            Pictures = new();
        }


        /// <summary>Creates a new instance of this class.</summary>
        protected Story()
        {
            Place = new();
            Pictures = new();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the story ID.</summary>
        [Key][Column("ID")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get; protected set;
        }


        /// <summary>Gets the place the story belongs to.</summary>
        [ForeignKey("PLACE_ID")]
        public Place Place 
        { 
            get; protected set; 
        }


        /// <summary>Gets or sets the story text.</summary>
        [Column("TEXT")]
        public string Text
        {
            get; set;
        } = string.Empty;


        /// <summary>Gets the file names of pictures associated with the story.</summary>
        [Column("PICTURES")]
        public List<string> Pictures
        {
            get; protected set;
        }
    }
}
