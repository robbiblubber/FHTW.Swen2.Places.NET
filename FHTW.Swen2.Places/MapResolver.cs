using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Web;

using FHTW.Swen2.Places.Model;



namespace FHTW.Swen2.Places
{
    /// <summary>This class provides map resolving functionality.</summary>
    public static class MapResolver
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private constants                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>API key.</summary>
        private const string _KEY = "5b3ce3597851110001cf62482f5e55d721404adb954236144e1ae077";



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public static methods                                                                                    //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Resolves latitude and longitude to coordinates.</summary>
        /// <param name="latitude">Latitude string.</param>
        /// <param name="longitude">Longitude string.</param>
        /// <returns>Returns a <see cref="Coordinates"/> instance or NULL if invalid.</returns>
        public static Coordinates? Resolve(string latitude, string longitude)
        {
            double lat = 0, lng = 0;
            if(!(double.TryParse(latitude, out lat) && double.TryParse(longitude, out lng)))
            {
                return null;
            }
            if((lat > 90) || (lat < -90)) { return null; }
            if((lng > 180) || (lat < -180)) { return null; }

            return new(lat, lng);
        }


        /// <summary>Resolves an address to coordinates.</summary>
        /// <param name="street">Street.</param>
        /// <param name="code">Code.</param>
        /// <param name="town">Town.</param>
        /// <param name="country">Country.</param>
        /// <returns>Returns coordinates if resolvable, otherwise returns NULL.</returns>
        public static Coordinates? Resolve(string street, string code, string town, string country)
        {
            double? lat = null, lng = null;

            using HttpClient cl = new();
            using JsonDocument data = JsonDocument.Parse(cl.GetAsync(
                $"https://api.openrouteservice.org/geocode/search?api_key={_KEY}&" +
                $"text?{HttpUtility.UrlEncode(street + ", " + code + ", " + town + ", " + country)}")
                .Result.Content.ReadAsStringAsync().Result ?? "");
            
            if(data == null) { return null; }

            try
            {
                if(data.RootElement.GetProperty("features").GetArrayLength() < 1) { return null; }

                lat = data.RootElement.GetProperty("features")[0]
                                      .GetProperty("geometry")
                                      .GetProperty("coordinates")[1].GetDouble();
                lng = data.RootElement.GetProperty("features")[0]
                                      .GetProperty("geometry")
                                      .GetProperty("coordinates")[0].GetDouble();
            }
            catch(Exception) { return null; }


            return new(lat ?? 0, lng ?? 0);
        }
    }
}
