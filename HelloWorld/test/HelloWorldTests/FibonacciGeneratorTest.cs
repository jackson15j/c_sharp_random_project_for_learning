using HelloWorld;
using System.Collections.Generic;
using Xunit;

public class FibonacciGeneratorTest
{
    /*
      Use Fact unittest to verify FibonacciGenerator.
    */
    [Fact]
    public void GenerateReturnsSequence()
    {
        List<int> expectedList = new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377};
        IEnumerable<int> generatedList = new FibonacciGenerator().Generate(15);

        Assert.Equal(expectedList, generatedList);
    }
}
