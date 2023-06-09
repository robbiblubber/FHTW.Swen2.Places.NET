using System;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents an address.</summary>
    public sealed record class Address(): ILocation
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="street">Street.</param>
        /// <param name="town">Town.</param>
        /// <param name="code">Postal code.</param>
        /// <param name="country">Country.</param>
        public Address(string street, string town, string code, string country): this()
        {
            Street = street;
            Town = town;
            Code = code;
            Country = country;
        }


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
