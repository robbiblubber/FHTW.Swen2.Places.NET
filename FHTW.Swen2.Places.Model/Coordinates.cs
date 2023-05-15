using System;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class represents location coordinates.</summary>
    public sealed class Coordinates: ILocation
    {
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
