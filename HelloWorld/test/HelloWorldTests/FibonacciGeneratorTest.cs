using HelloWorld;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xunit;


/*
  Class based generator, which contains multiple objects which can be consumed
  by xUnit's Theory testcases when data is passed in via a ClassData attribute.

  See: http://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/
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
  Fib class for testing the private `FibonacciGenerator.Fib()` method.
*/
public class Fib
{
    public int InitialValue {get; set;}
    public int ExpectedValue {get; set;}
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

    /*
      Using a static member, instead of creating the above IEnumerable test
      data class.
    */
    public static IEnumerable<object[]> FibonacciGeneratorTestMemberData()
    {
        yield return new object[] {new List<int> {0}};
        yield return new object[] {new List<int> {0, 1, 1, 2, 3, 5}};
        yield return new object[] {new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377}};
    }

    /*
      Use Member Data to cycle over Test data objects. Each object has a single
      argument which is a List.
    */
    [Theory]
    [MemberData(nameof(FibonacciGeneratorTestMemberData))]
    public void GenerateReturnsSequenceViaTestMemberData(List<int> expectedList)
    {
        Assert.Equal(expectedList, new FibonacciGenerator().Generate(expectedList.Count));
    }

    /*
      Using a static member to define test data for the private
      `FibonacciGenerator.Fib()` method. Uses the `Fib` class defined at the
      top of the file.
    */
    public static IEnumerable<object[]> FibTestMemberData()
    {
        yield return new object[] {new Fib {InitialValue = 0, ExpectedValue = 0}};
        yield return new object[] {new Fib {InitialValue = 1, ExpectedValue = 1}};
        yield return new object[] {new Fib {InitialValue = 2, ExpectedValue = 1}};
        yield return new object[] {new Fib {InitialValue = 3, ExpectedValue = 2}};
        yield return new object[] {new Fib {InitialValue = 4, ExpectedValue = 3}};
        yield return new object[] {new Fib {InitialValue = 5, ExpectedValue = 5}};
        yield return new object[] {new Fib {InitialValue = 6, ExpectedValue = 8}};
        yield return new object[] {new Fib {InitialValue = 7, ExpectedValue = 13}};
    }

    /*
      Use Reflection to test the `FibonacciGenerator.Fib()` private member.

      See:

      * https://stackoverflow.com/questions/15652656/get-return-value-after-invoking-a-method-from-dll-using-reflection#15652926
      * https://stackoverflow.com/questions/9122708/unit-testing-private-methods-in-c-sharp#15607491
    */
    [Theory]
    [MemberData(nameof(FibTestMemberData))]
    public void TestPrivateFibViaRelfection(Fib fibData)
    {
        FibonacciGenerator fibonacciGenerator = new FibonacciGenerator();
        MethodInfo methodInfo = typeof(FibonacciGenerator).GetMethod("Fib", BindingFlags.NonPublic | BindingFlags.Instance);
        object[] parameters = {fibData.InitialValue};
        int retVal = (int)methodInfo.Invoke(fibonacciGenerator, parameters);
        Assert.Equal(fibData.ExpectedValue, retVal);
    }
}
