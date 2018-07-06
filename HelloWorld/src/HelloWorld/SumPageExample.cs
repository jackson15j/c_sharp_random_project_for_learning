using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            // Using `foreach` in this way blocks each serial async call. See:
            // `SumPageSizesInParallelAndAsync()` to call them in parallel.
            byte[] urlContents = await GetURLContentsAsync(url);
            DisplayResults(url, urlContents);
            total += urlContents.Length;
        }
        Console.WriteLine(string.Format("\n\nTotal bytes returned: {0}", total));
    }

    /**
       Async wrapper to get a URL and munge to display in a human readable
       format, as per:

       * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall

       TODO: Separate out network calls from parsing/munging code and
       integration/unit test respectively.

       @param string url - URL to get and display in human readable format.
       @return int - Length of content.
     */
    private async Task<int> ProcessURLAsync(string url)
    {
        var byteArray = await GetURLContentsAsync(url);
        DisplayResults(url, byteArray);
        return byteArray.Length;
    }

    /**
       Asynchronous & parallel wrapper function to Get the content from a class
       defined list of URLs and display their respective lengths.
     */
    public async Task SumPageSizesInParallelAndAsync()
    {
        List<string> urlList = SetUpURLList();

        // Create a query.
        IEnumerable<Task<int>> downloadTasksQuery = from url in urlList select ProcessURLAsync(url);
        // Use ToArray to execute the query and start the download tasks.
        Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

        int[] lengths = await Task.WhenAll(downloadTasks);
        int total = lengths.Sum();
        Console.WriteLine(string.Format("\n\nTotal bytes returned: {0}", total));
    }

    /**
       Async wrapper to get a URL and munge to display in a human readable
       format, as per:

       * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await

       TODO: Separate out network calls from parsing/munging code and
       integration/unit test respectively.

       @param string url - URL to get and display in human readable format.
       @param HttpClient client - Client to make the request with.
       @return int - Length of content.
     */
    private async Task<int> ProcessURLAsync(string url, HttpClient client)
    {
        var byteArray = await client.GetByteArrayAsync(url);
        DisplayResults(url, byteArray);
        return byteArray.Length;
    }

    /**
       Create multiple Async tasks that are called from the same HttpClient.
     */
    public async Task CreateMultipleTasksAsync()
    {
        // Up buffer size from the default of: 65,536.
        HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

        // Create & Start tasks, but await on them later on.
        Task<int> download1 = ProcessURLAsync("http://msdn.microsoft.com", client);
        Task<int> download2 = ProcessURLAsync("http://msdn.microsoft.com/library/hh156528(VS.110).aspx", client);
        Task<int> download3 = ProcessURLAsync("http://msdn.microsoft.com/library/67w7t67f.aspx", client);

        // Await each task.
        int length1 = await download1;
        int length2 = await download2;
        int length3 = await download3;
        int total = length1 + length2 + length3;
        Console.WriteLine(string.Format("\n\nTotal bytes returned: {0}", total));
    }
}
