using System;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents a place.</summary>
    public class Place
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the place ID.</summary>
        public int ID
        {
            get; private set;
        }


        /// <summary>Gets or sets the place name.</summary>
        public string Name
        {
            get; set;
        } = "";


        /// <summary>Gets or sets the place description.</summary>
        public string Description
        {
            get; set;
        } = "";


        /// <summary>Gets or sets the place location.</summary>
        public ILocation? Location
        {
            get; set;
        }


        /// <summary>Gets or sets the place story list.</summary>
        public List<Story> Stories
        {
            get; private set;
        } = new();
    }
}