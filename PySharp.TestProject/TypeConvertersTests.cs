using PySharp;

[TestFixture]
public class TypeConvertersTests
{
    [Test]
    public void Float_ConvertsValidInputs()
    {
        Assert.AreEqual(3.14f, TypeConverters.@float(3.14f));
        Assert.AreEqual(3.0f, TypeConverters.@float(3));
        Assert.AreEqual(3.14f, TypeConverters.@float("3.14"));
    }

    [Test]
    public void Float_ThrowsFormatException_OnInvalidInput()
    {
        Assert.Throws<FormatException>(() => TypeConverters.@float("not a number"));
    }

    [Test]
    public void Int_ConvertsValidInputs()
    {
        Assert.AreEqual(3, TypeConverters.@int(3.14));
        Assert.AreEqual(42, TypeConverters.@int("42"));
        Assert.AreEqual(10, TypeConverters.@int("1010", 2));
    }

    [Test]
    public void Int_ThrowsFormatException_OnInvalidInput()
    {
        Assert.Throws<FormatException>(() => TypeConverters.@int("not a number"));
    }

    [Test]
    public void Chr_ReturnsCorrectCharacter()
    {
        Assert.AreEqual('A', TypeConverters.chr(65));
    }

    [Test]
    public void Chr_ThrowsArgumentOutOfRangeException_OnInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => TypeConverters.chr(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => TypeConverters.chr(0x110000));
    }

    [Test]
    public void Bool_ConvertsValidInputs()
    {
        Assert.IsFalse(TypeConverters.@bool(null));
        Assert.IsFalse(TypeConverters.@bool(false));
        Assert.IsFalse(TypeConverters.@bool(0));
        Assert.IsFalse(TypeConverters.@bool(""));
        Assert.IsTrue(TypeConverters.@bool(true));
        Assert.IsTrue(TypeConverters.@bool(42));
        Assert.IsTrue(TypeConverters.@bool("Hello, World!"));
    }
}
