using AltitudeAngel;
using System;
using Xunit;

namespace AltitudeAngelTest
{
    /**
       Integration tests against the Altitude Angel API class.
    */
    public class AltitudeAngelTest
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        // TODO: Add apiKey to an encrypted store outside of the repo for tests
        // and CI.
        static String apiKey = "";

        /**
           Verify the GetMapData method.


xxx response: StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: System.Net.Http.HttpConnection+HttpConnectionResponseContent, Headers:
{
  Cache-Control: no-cache
  Pragma: no-cache
  Server: AA-AwesomeServer
  Date: Fri, 20 Jul 2018 14:40:48 GMT
  Content-Length: 416297
  Content-Type: application/json; charset=utf-8
  Expires: -1
}

        */
        [Fact]
        public async void GetMapDataTest()
        {
            // FIXME: Need a test base class or somewhere else generic to setup
            // logging!!
            AppLog.ConfigureLogging();

            AltitudeAngelApi client = new AltitudeAngelApi(apiKey);
            MapData response = await client.GetMapData(
                51.46227963315035, -0.9569686575500782, 51.450125805383585, -0.9857433958618458);
            log.Info($"xxx response: {response}");
            foreach(Feature feature in response.features)
            {
                log.Info($"xxx features: {feature.properties.name}");
            }
        }
    }
}
