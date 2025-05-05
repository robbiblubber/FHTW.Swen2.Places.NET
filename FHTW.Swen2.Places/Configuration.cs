using System;



namespace FHTW.Swen2.Places
{
    /// <summary>This class contains application configuration data.</summary>
    internal sealed class Configuration
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets or sets the database file.</summary>
        public string DatabaseFile
        {
            get; set;
        } = @"C:\home\test\places.db";


        /// <summary>Gets the image path.</summary>
        public string ImagePath
        {
            get; set;
        } = @"C:\home\test\img";
    }
}
