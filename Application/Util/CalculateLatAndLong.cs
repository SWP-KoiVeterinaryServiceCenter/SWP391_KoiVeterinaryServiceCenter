using Application.Util.UitlModel;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Util
{
    public static  class CalculateLatAndLong
    {
        public static async  Task<Location> CalculateLatLongByAddressAsync(string address)
        {
            string NominatimUrl = "https://nominatim.openstreetmap.org/search";
            Location location = new Location();
            // Construct the full URL with query parameters
            string url = $"{NominatimUrl}?q={Uri.EscapeDataString(address)}&format=json&limit=1";

            // Create HttpClient
            using HttpClient client = new HttpClient();

            // Add a User-Agent header to avoid 403 Forbidden error
            client.DefaultRequestHeaders.Add("User-Agent", "C# Web API");

            try
            {
                var response = await client.GetFromJsonAsync<Location[]>(url);

                // Check if we got a result
                if (response != null && response.Length > 0)
                {
                  location = response[0];
                    Console.WriteLine($"Latitude: {location.Lat}, Longitude: {location.Lon}");
                }
                else
                {
                    Console.WriteLine("No location found.");
                }
            } catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
            
            }
            return location;

        }
    }
    
}
