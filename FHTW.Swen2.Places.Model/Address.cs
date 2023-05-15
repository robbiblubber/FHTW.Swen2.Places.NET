using System;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents an address.</summary>
    public sealed class Address: ILocation
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets or sets the street.</summary>
        public string Street
        {
            get; set;
        } = "";


        /// <summary>Gets or sets the postal code.</summary>
        public string Code
        {
            get; set;
        } = "";


        /// <summary>Gets or sets the town.</summary>
        public string Town
        {
            get; set;
        } = "";


        /// <summary>Gets or sets the country.</summary>
        public string Country
        {
            get; set;
        } = "";
    }
}
