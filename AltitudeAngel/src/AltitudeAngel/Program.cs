using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AltitudeAngel
{
    class Program
    {
        static Uri baseUri = new Uri("https://api.altitudeangel.com");
        static Dictionary<string, string> parameters = new Dictionary<string, string> {
            {"n", "51.46227963315035"},
            {"e", "-0.9569686575500782"},
            {"s", "51.450125805383585"},
            {"w", "-0.9857433958618458"}
        };
        static HttpResponseMessage response;


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


            Console.WriteLine("-- Parameters in RequestUri string...");
            // Build the request message.
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = authHeader;
            Console.WriteLine(request.Headers.Authorization);
            request.RequestUri = new Uri(baseUri, "/v2/mapdata/geojson?n=51.46227963315035&e=-0.9569686575500782&s=51.450125805383585&w=-0.9857433958618458");
            Console.WriteLine(request.RequestUri);
            request.Method = HttpMethod.Get;

            // Synchronous call the async function for the HTTP Response.
            // HttpResponseMessage response = client.SendAsync(request).Result;
            // Console.WriteLine($"Status code: {response.StatusCode}");



            Console.WriteLine("-- URI & Parameters built together via System.Web.UriBuilder...");
            var builder = new UriBuilder($"{baseUri}v2/mapdata/geojson");
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach(var param in parameters) {
                query[param.Key] = param.Value;
            }
            builder.Query = query.ToString();
            request.Headers.Authorization = authHeader;
            request.RequestUri = builder.Uri;
            Console.WriteLine(request.RequestUri);
            request.Method = HttpMethod.Get;

            // Synchronous call the async function for the HTTP Response.
            response = client.SendAsync(request).Result;
            Console.WriteLine($"Status code: {response.StatusCode}");






            Console.WriteLine("-- Parameters built via FormUrlEncodedContent and then munged into RequestUri...");
            // Build the request message.
            request = new HttpRequestMessage();
            var encodedParameters = new FormUrlEncodedContent(parameters);
            Console.WriteLine(encodedParameters);
            request.Headers.Authorization = authHeader;
            foreach(var param in parameters) {
                request.Headers.Add(param.Key, param.Value);
            }
            request.RequestUri = new Uri(baseUri, $"/v2/mapdata/geojson?{encodedParameters.ReadAsStringAsync().Result}");
            Console.WriteLine(request.RequestUri);
            request.Method = HttpMethod.Get;

            // Synchronous call the async function for the HTTP Response.
            // response = client.SendAsync(request).Result;
            // Console.WriteLine($"Status code: {response.StatusCode}");
        }
    }
}
