using log4net.Core;



namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class contains application configuration data.</summary>
    public sealed class Configuration
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets or sets the database file.</summary>
        public string DatabaseFile
        {
            get; set;
        } = @"C:\home\test\places.db";


        /// <summary>Gets or sets the log level for the application.</summary>
        public Level LogLevel
        {
            get; set;
        } = Level.Info;
    }
}
