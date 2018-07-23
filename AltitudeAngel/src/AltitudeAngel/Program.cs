using System;
using System.Collections.Generic;

namespace AltitudeAngel
{
    class Program
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            AppLog.ConfigureLogging();

            // TODO: Create entry points into the code like git/dotnet:
            // `aa weather <lon> <lat>`
            // `aa mapData <lon> <lat> <size>` or `aa mapData <n> <e> <s> <w>`
            if (args.Length != 1)
            {
                log.Info("Application requires an Altitude Angel API key to be supplied!!");
                NLog.LogManager.Shutdown();
                Environment.Exit(1);
            }

            // Create an Authorization header with the CLI supplied API key.
            string apiKey = args[0];
            AltitudeAngelApi aaClient = new AltitudeAngelApi(apiKey);
            // Synchronous call the async function for the HTTP Response.
            // FIXME: don't hard-code coordinates.
            MapData response = aaClient.GetMapData(
                51.46227963315035, -0.9569686575500782, 51.450125805383585, -0.9857433958618458).Result;
            List<string> names = new List<string>();;
            foreach(Feature feature in response.features)
            {
                names.Add(feature.properties.name);
            }
            log.Info("MapData Feature Names: {0}", String.Join(", ", names));

            NLog.LogManager.Shutdown();
        }
    }
}
