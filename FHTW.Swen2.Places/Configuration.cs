using System;
using System.IO;
using System.Text.Json;



namespace FHTW.Swen2.Places
{
    /// <summary>This class contains application configuration data.</summary>
    public sealed class Configuration
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private constants                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private const string _FILENAME = @"C:\home\test\places.config";




        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private static members                                                                                   //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Singleton instance.</summary>
        private static Configuration? _Instance = null;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        public Configuration()
        {}



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public static properties                                                                                 //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets an instance of the configuration.</summary>
        public static Configuration Instance
        {
            get
            {
                if(_Instance == null)
                {
                    if(File.Exists(_FILENAME))
                    {
                        _Instance = JsonSerializer.Deserialize<Configuration>(File.ReadAllText(_FILENAME));
                    }

                    if(_Instance == null) { _Instance = new(); }
                }

                return _Instance;
            }
        }



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



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Saves the configuration.</summary>
        public void Save()
        {
            File.WriteAllText(_FILENAME, JsonSerializer.Serialize(this));
        }
    }
}
