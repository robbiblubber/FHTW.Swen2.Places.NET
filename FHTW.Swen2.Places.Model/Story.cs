using System;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents a story for a place.</summary>
    public sealed class Story
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="place">Place.</param>
        public Story(Place place)
        {
            Place = place;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets the place for the story.</summary>
        public Place Place
        {
            get; private set;
        }


        /// <summary>Gets the story ID.</summary>
        public int ID
        {
            get; private set;
        }


        /// <summary>Gets the story text.</summary>
        public string Text
        {
            get; set;
        } = "";


        public List<string> Pictures
        {
            get; private set;
        } = new();
    }
}
