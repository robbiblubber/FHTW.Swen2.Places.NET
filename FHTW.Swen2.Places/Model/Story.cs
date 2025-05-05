using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;



namespace FHTW.Swen2.Places.Model
{
    [Table("STORIES")][PrimaryKey("ID")]
    public class Story
    {
        public Story(Place place) 
        {
            Place = place;
        }


        protected Story()
        {
            Place = new();
        }


        [ForeignKey("PLACE_ID")]
        public Place Place 
        { 
            get; protected set; 
        }


        [Key][Column("ID")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get; protected set;
        }


        [Column("TEXT")]
        public string Text
        {
            get; set;
        } = string.Empty;


        [Column("PICTURES")]
        public List<string> Pictures
        {
            get; protected set;
        }
    }
}
