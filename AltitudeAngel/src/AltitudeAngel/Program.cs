using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AltitudeAngel
{
    class Program
    {
        static Uri baseUri = new Uri("https://api.altitudeangel.com");

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Application requires an Altitude Angel API key to be supplied!!");
                Environment.Exit(1);
            }

            // Create an Authorization header with the CLI supplied API key.
            string apiKey = args[0];
            AuthenticationHeaderValue authHeader = new AuthenticationHeaderValue("X-AA-ApiKey", apiKey);

            // TODO: Use a handler to store the authorization on the client.
            HttpClient client = new HttpClient();

            // Build the request message.
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = authHeader;
            Console.WriteLine(request.Headers.Authorization);
            request.RequestUri = new Uri($"{baseUri}/v2/mapdata/geojson?n=51.46227963315035&e=-0.9569686575500782&s=51.450125805383585&w=-0.9857433958618458");
            request.Method = HttpMethod.Get;

            // Synchronous call the async function for the HTTP Response.
            HttpResponseMessage response = client.SendAsync(request).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
