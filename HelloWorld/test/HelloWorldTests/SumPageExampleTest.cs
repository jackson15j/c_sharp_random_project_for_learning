using System.Text;
using Xunit;

/**
   Tests for the synchronous example for Summing Web Pages. See:

   * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await

   NOTE: that the example had no tests.
   NOTE: Using inheritance to test the protected methods that are now a part of
   my test class. Undecided if this is better than reflection testing private
   methods, or making everything public. **INVESTIGATE:** common consensus.
 */
public class SumPageExampleTest : SumPageExample
{
    [Fact]
    public void GetHumanReadableResultsTest()
    {
        string expDisplayedUrl = "my-fake-site.com/it-is/not/real.html";
        string url = $"http://{expDisplayedUrl}";
        string contentString = "The body of my fake website.\n\nIt is great!";
        byte[] contentByte = Encoding.UTF8.GetBytes(contentString);
        int expContentLength = contentByte.Length;

        string expDisplayOutput = string.Format("\n{0, -58} {1,8}", expDisplayedUrl, expContentLength);

        Assert.Equal(expDisplayOutput, new SumPageExampleTest().GetHumanReadableResults(url, contentByte));
    }
}
