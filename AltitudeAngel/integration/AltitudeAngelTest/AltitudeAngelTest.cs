using AltitudeAngel;
using System;
using System.Net.Http;
using Xunit;

namespace AltitudeAngelTest
{
    /**
       Integration tests against the Altitude Angel API class.
    */
    public class AltitudeAngelTest
    {
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
            AltitudeAngelApi client = new AltitudeAngelApi(apiKey);
            HttpResponseMessage response = await client.GetMapData(
                51.46227963315035, -0.9569686575500782, 51.450125805383585, -0.9857433958618458);
            Console.WriteLine($"xxx response: {response}");

        }
    }
}
