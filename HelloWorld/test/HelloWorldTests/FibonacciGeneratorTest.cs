using HelloWorld;
using System.Collections;
using System.Collections.Generic;
using Xunit;

/*
  Class based generator, which contains multiple objects which can be consumed
  by xUnit's Theory testcases when data is passed in via a ClassData attribute.
*/
public class FibonacciGeneratorTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {new List<int> {0}},
        new object[] {new List<int> {0, 1, 1, 2, 3, 5}},
        new object[] {new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377}}
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


/*
  FibonacciGeneratorTest which uses xUnit's Fact / Theory attributes to
  accomplish the same test in multiple ways.
 */
public class FibonacciGeneratorTest
{
    /*
      Use Fact unittest to verify FibonacciGenerator. Tests in isolation as a
      single testcase.
    */
    [Fact]
    public void GenerateReturnsSequence()
    {
        List<int> expectedList = new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377};
        IEnumerable<int> generatedList = new FibonacciGenerator().Generate(15);

        Assert.Equal(expectedList, generatedList);
    }

    /*
      Use Class Data to cycle over Test data objects. Each object has a single
      argument which is a List.

      Each object runs the test in isolation, so X objects = X testcases.
    */
    [Theory]
    [ClassData(typeof(FibonacciGeneratorTestData))]
    public void GenerateReturnsSequenceViaTestClassData(List<int> expectedList)
    {
        Assert.Equal(expectedList, new FibonacciGenerator().Generate(expectedList.Count));
    }
}
