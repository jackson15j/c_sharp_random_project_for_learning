using System.Text;
using Xunit;
using Xunit.Abstractions;

/**
   Integration Tests for the synchronous example for Summing Web Pages. See:

   * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await

   NOTE: that the example had no tests.
   NOTE: guessing on name & folder hierarchy for integration tests.
   **INVESTIGATE:** common C# consensus.
 */
public class SumPageExampleITest
{
    ITestOutputHelper output;

    /**
       xUnit swallows `Console.Write*()`, so using the suggested method until I
       implement a logger:

       * https://github.com/xunit/samples.xunit/blob/master/TestOutputExample/Example.cs
     */
    public SumPageExampleITest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void GetURLContentsTest()
    {
        // FIXME: Site is not under my control, so fragile to test against it.
        string expString = "Learn to Develop with Microsoft Developer Network | MSDN";
        string url = "https://msdn.microsoft.com";
        byte[] content = new SumPageExample().GetURLContents(url);
        // INVESTIGATE: Why does `byte[].ToString()` return `"System.Byte[]`
        // instead of the string within the byte array?? Feels like a Gotcha
        // that describes it's own object, rather than the contents.
        string contentString = Encoding.UTF8.GetString(content);
        // Commented out due to size of printing page source.
        // output.WriteLine($"XXX - content: {contentString}");
        Assert.Contains(expString, contentString);
        // FIXME: Again, fragile to test like this on an external site.
        output.WriteLine($"XXX - content Length: {content.Length}");
        Assert.InRange(content.Length, 30000, 50000);
    }
}
