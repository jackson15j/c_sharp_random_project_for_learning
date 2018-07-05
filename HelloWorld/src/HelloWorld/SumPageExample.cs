using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/**
   Synchronous example for Summing Web Pages. See:

   * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await

   Code modified to work as a, non-Visual Studio, Console application.
 */
public class SumPageExample {

    /**
       List of URLs for test data.
    */
    private List<string> SetUpURLList()
    {
        var urls = new List<string>
        {
            "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
            "http://msdn.microsoft.com",
            "http://msdn.microsoft.com/library/hh290136.aspx",
            "http://msdn.microsoft.com/library/ee256749.aspx",
            "http://msdn.microsoft.com/library/hh290138.aspx",
            "http://msdn.microsoft.com/library/hh290140.aspx",
            "http://msdn.microsoft.com/library/dd470362.aspx",
            "http://msdn.microsoft.com/library/aa578028.aspx",
            "http://msdn.microsoft.com/library/ms404677.aspx",
            "http://msdn.microsoft.com/library/ff730837.aspx"
        };
        return urls;
    }

    /**
       Public method (to lazy to test via reflection

       @param string url - URL to display alongside page size.
       @param byte[] content - Page content from the provided URL.
     */
    protected string GetHumanReadableResults(string url, byte[] content)
    {
        var bytes = content.Length;
        // regex replace all schemas: "http://", "https://", "ftp://", etc...
        var displayURL = Regex.Replace(url, "^.*:\\/\\/", "");
        return string.Format("\n{0, -58} {1,8}", displayURL, bytes);
    }

    /**
       Grabs length of content, munges url, and prints both to console in human
       readable columns.

       @param string url - URL to display alongside page size.
       @param byte[] content - Page content from the provided URL.
     */
    private void DisplayResults(string url, byte[] content)
    {
        Console.Write(GetHumanReadableResults(url, content));
    }

    /**
       Synchronous call to get the page contents for the provided URL.

       @param string url - URL to get page content for.
       @returns byte[].
     */
    public byte[] GetURLContents(string url)
    {
        var content = new MemoryStream();
        var WebReq = (HttpWebRequest)WebRequest.Create(url);

        using (WebResponse response = WebReq.GetResponse())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                responseStream.CopyTo(content);
            }
        }
        return content.ToArray();
    }

    /**
       Asynchronous call to get the page contents for the provided URL.

       @param string url - URL to get page content for.
       @returns byte[].
     */
    public async Task<byte[]> GetURLContentsAsync(string url)
    {
        var content = new MemoryStream();
        var WebReq = (HttpWebRequest)WebRequest.Create(url);

        using (WebResponse response = await WebReq.GetResponseAsync())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                await responseStream.CopyToAsync(content);
            }
        }
        return content.ToArray();
    }

    /**
       Synchronous wrapper function to Get the content from a class defined
       list of URLs and display their respective lengths.
     */
    public void SumPageSizes()
    {
        List<string> urlList = SetUpURLList();

        var total = 0;
        foreach (var url in urlList)
        {
            byte[] urlContents = GetURLContents(url);
            DisplayResults(url, urlContents);
            total += urlContents.Length;
        }
        Console.WriteLine(string.Format("\n\nTotal bytes returned: {0}", total));
    }

    /**
       Asynchronous wrapper function to Get the content from a class defined
       list of URLs and display their respective lengths.
     */
    public async Task SumPageSizesAsync()
    {
        List<string> urlList = SetUpURLList();

        var total = 0;
        foreach (var url in urlList)
        {
            // FIXME: Using `foreach` in this way blocks each serial async
            // call. Need to change the code to call them in parallel.
            byte[] urlContents = await GetURLContentsAsync(url);
            DisplayResults(url, urlContents);
            total += urlContents.Length;
        }
        Console.WriteLine(string.Format("\n\nTotal bytes returned: {0}", total));
    }
}
