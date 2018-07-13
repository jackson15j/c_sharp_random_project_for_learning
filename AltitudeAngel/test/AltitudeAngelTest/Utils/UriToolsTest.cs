using System;
using System.Collections.Generic;
using Xunit;

namespace AltitudeAngelTest
{
    public class MapData
    {
        public Uri baseUri { get; set; }
        public Dictionary<string, string> parameters { get; set; }
        public Uri expUri { get; set; }
    }


    public class UriToolsTest
    {
        static Uri baseUri = new Uri("https://api.altitudeangel.com");
        static Uri mapDataUri = new Uri(baseUri, "/v2/mapdata/geojson");
        static Dictionary<string, string> parameters = new Dictionary<string, string> {
            {"n", "51.46227963315035"},
            {"e", "-0.9569686575500782"},
            {"s", "51.450125805383585"},
            {"w", "-0.9857433958618458"}
        };
        static Uri expUri = new Uri("https://api.altitudeangel.com/v2/mapdata/geojson?n=51.46227963315035&e=-0.9569686575500782&s=51.450125805383585&w=-0.9857433958618458");

        public static IEnumerable<object[]> mapDataTestMemberData()
        {
            yield return new object[] { new MapData {
                    baseUri = mapDataUri,
                    parameters = parameters,
                    expUri = expUri}
            };
        }

        [Theory]
        [MemberData(nameof(mapDataTestMemberData))]
        public void BuildRequestUriTest(MapData mapData)
        {
            Assert.Equal(mapData.expUri, UriTools.BuildRequestUri(mapData.baseUri, mapData.parameters));
        }
    }
}
