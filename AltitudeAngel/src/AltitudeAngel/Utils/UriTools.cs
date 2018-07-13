using System;
using System.Collections.Generic;
// using System.Net.Http;  // Used by commented out `BuildRequestUri()`.
using System.Web;

/**
   Utility class that provides URI helper methods.
*/
class UriTools
{
    /**
       Builds a URI with query parameters to be used in a GET request.

       @param String uri - Base URI to build the Query string onto.
       @param Dictionary<string, string> queryParameters - Dictionary of
               Query parameters to apply to the base URI.
       @returns Uri.
     */
    static public Uri BuildRequestUri(String uri, Dictionary<string, string> queryParameters)
    {
        return BuildRequestUri(new Uri(uri), queryParameters);
    }

    /**
       Builds a URI with query parameters to be used in a GET request.

       @param Uri uri - Base URI to build the Query string onto.
       @param Dictionary<string, string> queryParameters - Dictionary of
               Query parameters to apply to the base URI.
       @returns Uri.
     */
    static public Uri BuildRequestUri(Uri uri, Dictionary<string, string> queryParameters)
    {
        var builder = new UriBuilder(uri);
        var query = HttpUtility.ParseQueryString(builder.Query);
        foreach(var param in queryParameters) {
            query[param.Key] = param.Value;
        }
        builder.Query = query.ToString();

        return builder.Uri;
    }

    // /**
    //    Alternative `BuildRequestUri()` method. Not a fan, since I'm still
    //    munging the base uri and query strings together.

    //    Bonus: uses; `System.Net.Http` like the rest of the HttpClient code.

    //    FIXME: remove string munging if possible.
    //  */
    // static Uri BuildRequestUri(String uri, Dictionary<string, string> queryParameters)
    // {
    //     var encodedParameters = new FormUrlEncodedContent(queryParameters);
    //     return new Uri($"{uri}?{encodedParameters.ReadAsStringAsync().Result}");
    // }
}
