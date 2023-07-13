using PySharp;

[TestFixture]
public class NumPyTests
{
    private const double Tolerance = 1e-6;

    [Test]
    public void TestArange()
    {
        var result = NumPy.Arange(0, 10, 2);
        var expected = new double[] { 0, 2, 4, 6, 8 };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestLinspace()
    {
        var result = NumPy.Linspace(0, 1, 5);
        var expected = new double[] { 0, 0.25, 0.5, 0.75, 1 };
        Assert.IsTrue(result.Zip(expected, (a, b) => Math.Abs(a - b) < Tolerance).All(x => x));
    }

    [Test]
    public void TestDot()
    {
        var a = new double[] { 1, 2, 3 };
        var b = new double[] { 4, 5, 6 };
        var result = NumPy.Dot(a, b);
        var expected = 32.0;
        Assert.AreEqual(expected, result, Tolerance);
    }

    [Test]
    public void TestReshape()
    {
        var a = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        var result = (double[,])NumPy.Reshape(a, 3, 2);
        var expected = new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestSum()
    {
        var a = new double[] { 1, 2, 3, 4, 5 };
        var result = NumPy.Sum(a);
        var expected = 15.0;
        Assert.AreEqual(expected, result, Tolerance);
    }

    [Test]
    public void TestMean()
    {
        var a = new double[] { 1, 2, 3, 4, 5 };
        var result = NumPy.Mean(a);
        var expected = 3.0;
        Assert.AreEqual(expected, result, Tolerance);
    }

    [Test]
    public void TestStdPopulation()
    {
        var a = new double[] { 1, 2, 3, 4, 5 };
        var result = NumPy.Std(a);
        var expected = Math.Sqrt(2.0);
        Assert.AreEqual(expected, result, Tolerance);
    }

    [Test]
    public void TestStdSample()
    {
        var a = new double[] { 1, 2, 3, 4, 5 };
        var result = NumPy.Std(a, 1);
        var expected = Math.Sqrt(2.5);
        Assert.AreEqual(expected, result, Tolerance);
    }
}