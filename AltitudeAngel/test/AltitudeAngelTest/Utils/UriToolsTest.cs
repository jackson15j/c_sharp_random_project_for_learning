using System;
using System.Collections.Generic;
using Xunit;

namespace AltitudeAngelTest
{
    public class MapData
    {
        public String baseString { get; set; }
        public Uri baseUri { get; set; }
        public Dictionary<string, string> parameters { get; set; }
        public Uri expUri { get; set; }
    }


    public class UriToolsTest
    {
        static Uri baseUri = new Uri("https://api.altitudeangel.com");
        static Uri mapDataUri = new Uri(baseUri, "/v2/mapdata/geojson");
        static String mapDataString = "https://api.altitudeangel.com/v2/mapdata/geojson";
        static Dictionary<string, string> parameters = new Dictionary<string, string> {
            {"n", "51.46227963315035"},
            {"e", "-0.9569686575500782"},
            {"s", "51.450125805383585"},
            {"w", "-0.9857433958618458"}
        };
        static Uri expUri = new Uri("https://api.altitudeangel.com/v2/mapdata/geojson?n=51.46227963315035&e=-0.9569686575500782&s=51.450125805383585&w=-0.9857433958618458");

        public static IEnumerable<object[]> mapDataTestMemberData()
        {
            // +ve: Verify Uri + parameters
            yield return new object[] { new MapData {
                    baseUri = mapDataUri,
                    parameters = parameters,
                    expUri = expUri}
            };
            // +ve: Verify String + parameters
            yield return new object[] { new MapData {
                    baseString = mapDataString,
                    parameters = parameters,
                    expUri = expUri}
            };
            // -ve: Verify Uri + null parameters = no munging of URI
            yield return new object[] { new MapData {
                    baseUri = mapDataUri,
                    parameters = null,
                    expUri = mapDataUri}
            };
            // -ve: Verify String + null parameters = no munging of URI
            yield return new object[] { new MapData {
                    baseString = mapDataString,
                    parameters = new Dictionary<String, String>(),
                    expUri = mapDataUri}
            };
            // -ve: Verify Uri + empty parameters = no munging of URI
            yield return new object[] { new MapData {
                    baseUri = mapDataUri,
                    parameters = null,
                    expUri = mapDataUri}
            };
            // -ve: Verify String + empty parameters = no munging of URI
            yield return new object[] { new MapData {
                    baseString = mapDataString,
                    parameters = new Dictionary<String, String>(),
                    expUri = mapDataUri}
            };
        }

        /**
           Quick test of the `UriTools.BuildRequestUri()` method.

           @param MapData mapData - Expects a mapData instance to be passed in
                   via the MemberData annotation.
         */
        [Theory]
        [MemberData(nameof(mapDataTestMemberData))]
        public void BuildRequestUriTest(MapData mapData)
        {
            Uri result;
            if (mapData.baseUri == null)
            {
                result = UriTools.BuildRequestUri(mapData.baseString, mapData.parameters);
            }
            else
            {
                result = UriTools.BuildRequestUri(mapData.baseUri, mapData.parameters);
            }
            Assert.Equal(mapData.expUri, result);
        }
    }
}
