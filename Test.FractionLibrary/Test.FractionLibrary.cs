namespace Test.FractionLibrary;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1, 2, 1, 2, 2, 2, "OK")]
    [TestCase(1, 2, 1, 3, 5, 6, "OK")]
    [TestCase(1, 0, 2, 3, 0, 0, "Divide by 0")]
    [TestCase(1, 2, 1, 0, 0, 0, "Divide by 0")]
    [TestCase(1, 2, 1, 2147483647, 0, 0, "Integer Overflow")]
    public void TestAddFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator, int ResultNumerator, int ResultDenominator, string status)
    {
        // Assert.Pass();
        var result = Fraction.AddFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
            Assert.That(result.Status, Is.EqualTo(status));
        });
    }

    [Test]
    [TestCase(2,3,1,3,1,3,"OK")]
    [TestCase(2,3,1,2,1,6,"OK")]
    [TestCase(2,3,1,0,0,0,"Divide by 0")]
    [TestCase(2,3,1,2147483647,0,0,"Integer Overflow")]
    [TestCase(2,int.MaxValue,1,int.MinValue,0,0,"Integer Overflow")]        
    public void TestSubtractFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator, int ResultNumerator, int ResultDenominator, string status)
    {
        var result = Fraction.SubtractFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
            Assert.That(result.Status, Is.EqualTo(status));
        });
    }

    [Test]
    [TestCase(2,3,1,3,2,9,"OK")]
    [TestCase(2,3,1,2,2,6,"OK")]
    [TestCase(2,3,1,0,0,0,"Divide by 0")]
    [TestCase(2,3,1,2147483647,0,0,"Integer Overflow")]
    [TestCase(2,int.MaxValue,1,int.MinValue,0,0,"Integer Overflow")]
    public void TestMultiplyFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator, int ResultNumerator, int ResultDenominator, string status)
    {
        var result = Fraction.MultiplyFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
            Assert.That(result.Status, Is.EqualTo(status));
        });
    }

    [Test]
    [TestCase(2,3,1,3,6,3,"OK")]
    [TestCase(2,3,1,2,4,3,"OK")]
    [TestCase(2,3,1,0,0,0,"Divide by 0")]
    [TestCase(2,3,1,2147483647,0,0,"Integer Overflow")]
    [TestCase(2,int.MaxValue,1,int.MinValue,0,0,"Integer Overflow")]
    public void TestDivideFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator, int ResultNumerator, int ResultDenominator, string status)
    {
        var result = Fraction.DivideFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
            Assert.That(result.Status, Is.EqualTo(status));
        });
    }

    [Test]
    [TestCase(4,6,2,3)]
    [TestCase(1,3,1,3)]
    [TestCase(100,200,1,2)]
    public void TestSimplifyFraction(int FirstNumerator, int FirstDenominator, int ResultNumerator, int ResultDenominator)
    {
        var result = Fraction.SimplifyFraction(FirstNumerator, FirstDenominator);
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
        });
    }

    [Test]
    [TestCase(3,2,1,1,2,"OK")]
    [TestCase(5,2,2,1,2,"OK")]
    [TestCase(1,2,0,1,2,"OK")]
    [TestCase(17,3,5,2,3,"OK")]
    public void TestMixedFraction(int FirstNumerator, int FirstDenominator, int ResultUnit, int ResultNumerator, int ResultDenominator, string status)
    {
        var result = Fraction.MixedFraction(FirstNumerator, FirstDenominator);
        Assert.Multiple(() =>
        {
            Assert.That(result.Unit, Is.EqualTo(ResultUnit));
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
            Assert.That(result.Status, Is.EqualTo(status));
        });
    }

    [Test]
    [TestCase(3,1,2,7,2,"OK")]
    [TestCase(5,2,2,12,2,"OK")]
    public void TestToFraction(int Unit, int Numerator, int Denominator, int ResultNumerator, int ResultDenominator, string status)
    {
        var result = Fraction.MakeFraction(Unit, Numerator, Denominator);
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
            Assert.That(result.Status, Is.EqualTo(status));
        });
    }

    [Test]
    [TestCase(0.5,1,2)]
    [TestCase(0.75,3,4)]
    public void TestToFraction(double Value, int ResultNumerator, int ResultDenominator)
    {
        var result = Fraction.DecimalToFractionApprox(Value);
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(ResultNumerator));
            Assert.That(result.Denominator, Is.EqualTo(ResultDenominator));
        });
    }
}