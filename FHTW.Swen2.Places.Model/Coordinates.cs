using System;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents location coordinates.</summary>
    public sealed record class Coordinates(): ILocation
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        internal Coordinates(double latitude, double longitude): this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets or sets the latitude.</summary>
        public double Latitude
        {
            get; set;
        }


        /// <summary>Gets or sets the longitude.</summary>
        public double Longitude
        {
            get; set;
        }
    }
}
