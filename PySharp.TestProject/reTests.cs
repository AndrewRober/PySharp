using PySharp;

using System.Text.RegularExpressions;

[TestFixture]
public class reTests
{
    [Test]
    public void Sub_WithNoCountParameter_ReplacesAllOccurrences() => 
        Assert.AreEqual("abcXdefX", re.sub(@"\d+", "X", "abc123def456"));

    [Test]
    public void Sub_WithCountParameter_ReplacesLimitedOccurrences() =>
        Assert.AreEqual("abcXdefXghi789",
            re.sub(@"\d+", "X", "abc123def456ghi789", 2));

    // Tests for compile()
    [Test]
    public void Compile_WithNoFlagsParameter_CompilesCorrectly() => 
        Assert.IsTrue(re.compile(@"\d+").IsMatch("abc123def"));

    [Test]
    public void Compile_WithFlagsParameter_CompilesCorrectly() => 
        Assert.IsTrue(re.compile(@"[A-Z]+", RegexOptions.IgnoreCase).IsMatch("abcDEF"));

    // Tests for match()
    [Test]
    public void Match_PatternMatchesAtStart_ReturnsMatch()
    {
        Match result = re.match(@"\d+", "123abc");
        Assert.IsNotNull(result);
        Assert.AreEqual("123", result.Value);
    }

    [Test]
    public void Match_PatternDoesNotMatchAtStart_ReturnsNull() => 
        Assert.IsNull(re.match(@"\d+", "abc123"));

    // Tests for findall()
    [Test]
    public void FindAll_ReturnsAllNonOverlappingOccurrences() => 
        Assert.AreEqual(new List<string> { "123", "456", "789" },
            re.findall(@"\d+", "abc123def456ghi789"));

    // Tests for finditer()
    [Test]
    public void FindIter_ReturnsAllNonOverlappingOccurrences() => 
        Assert.AreEqual(new List<string> { "123", "456", "789" },
            re.finditer(@"\d+", "abc123def456ghi789")
            .Select(match => match.Value).ToList());
}