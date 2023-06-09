using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;

namespace FHTW.Swen2.Places.Model
{
    /// <summary>This class implements map functionality.</summary>
    public static class MapData
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private constants                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>MapQuest API key.</summary>
        private const string _KEY = "q1K3pzb83YojoBjAN8vA9ROVqnBEHNvr";



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public static methods                                                                                    //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Resolves an address.</summary>
        /// <param name="street">Street.</param>
        /// <param name="code">Postal code.</param>
        /// <param name="town">Town.</param>
        /// <param name="country">Country.</param>
        /// <param name="coordinates">Coordinates.</param>
        /// <returns>Returns TRUE if the address has been successfully resolved,
        ///          otherwise returns FALSE.</returns>
        public static bool ResolveAddress(string street, string code, string town, string country, out Coordinates coordinates)
        {
            return ResolveAddress(new Address(street, code, town, country), out coordinates);
        }


        /// <summary>Tries to resolve an address.</summary>
        /// <param name="address">Address.</param>
        /// <param name="coordinates">Result coordinates.</param>
        /// <returns>Returns TRUE if the address has been successfully resolved,
        ///          otherwise returns FALSE.</returns>
        public static bool ResolveAddress(Address address, out Coordinates coordinates)
        {
            double? lat = null, lng = null;
            bool rval = false;

            HttpClient cl = new();

            JsonNode? data = JsonNode.Parse(cl.GetAsync("https://www.mapquestapi.com/geocoding/v1/" +
                                           $"address?key={_KEY}&street={HttpUtility.UrlEncode(address.Street)}" +
                                           $"&postalCode={HttpUtility.UrlEncode(address.Code)}" +
                                           $"&city={HttpUtility.UrlEncode(address.Town)}" +
                                           $"&country={HttpUtility.UrlEncode(address.Country)}&outFormat=json").Result.Content.ReadAsStringAsync().Result ?? "");

            if(data != null ) 
            {
                try
                {
                    if(((int?) data["info"]?["statuscode"]?.AsValue() ?? -1) == 0)
                    {
                        data = data["results"]?[0]?["locations"]?[0];

                        if(data != null)
                        {
                            if(!string.IsNullOrWhiteSpace((string?) data["street"]?.AsValue()))
                            {
                                lat = (double?) data["latLng"]?["lat"]?.AsValue();
                                lng = (double?) data["latLng"]?["lng"]?.AsValue();

                                rval = ((lat != null) && (lng != null));
                            }
                        }
                    }
                }
                catch(Exception) {}
            }

            coordinates = new(lat ?? 0, lng ?? 0);
            return rval;
        }


        public static bool ResolveCoordinates(string latitude, string longitude, out Coordinates coordinates)
        {
            double lat = 0, lng = 0;
            bool rval = double.TryParse(latitude, out lat) &&
                        double.TryParse(longitude, out lng);

            if((lat > 90) || (lat < -90)) { lat = lng = 0; rval = false; }
            if((lng > 180) || (lat < -180)) { lat = lng = 0; rval = false; }

            coordinates = new(lat, lng);
            return rval;
        }


        /// <summary>Generates a map.</summary>
        /// <param name="location">Location.</param>
        /// <param name="fileName">File name.</param>
        public static void GenerateMap(ILocation location, string fileName)
        {
            Coordinates c = new();

            if(location is Address)
            {
                ResolveAddress((Address) location, out c);
            }
            else { c = (Coordinates) location; }

            HttpClient cl = new();

            byte[] pic =
                   cl.GetByteArrayAsync("https://www.mapquestapi.com/staticmap/v5/" +
                   $"map?key={_KEY}&center={(c.Latitude + .004).ToString().Replace(',', '.')},{(c.Longitude + .004).ToString().Replace(',', '.')}" +
                   $"&locations={c.Latitude.ToString().Replace(',', '.')},{c.Longitude.ToString().Replace(',', '.')}|marker=3B5998-sm&size=300,200&zoom=13").Result;

            File.WriteAllBytes(fileName, pic);
        }
    }
}
