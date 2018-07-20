using System;

namespace AltitudeAngel
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create entry points into the code like git/dotnet:
            // `aa weather <lon> <lat>`
            // `aa mapData <lon> <lat> <size>` or `aa mapData <n> <e> <s> <w>`
            if (args.Length != 1)
            {
                Console.WriteLine("Application requires an Altitude Angel API key to be supplied!!");
                Environment.Exit(1);
            }

            // Create an Authorization header with the CLI supplied API key.
            string apiKey = args[0];
            AltitudeAngelApi aaClient = new AltitudeAngelApi(apiKey);
            // Synchronous call the async function for the HTTP Response.
            // FIXME: don't hard-code coordinates.
            MapData response = aaClient.GetMapData(
                51.46227963315035, -0.9569686575500782, 51.450125805383585, -0.9857433958618458).Result;
            Console.WriteLine("MapData Feature Names: ");
                foreach(Feature feature in response.features)
            {
                Console.Write($"{feature.properties.name}, ");
            }
        }
    }
}
