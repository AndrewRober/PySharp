using PySharp;

[TestFixture]
public class RandomTests
{
    [Test]
    public void Randint_GeneratesNumberWithinRange()
    {
        const int lowerBound = 1;
        const int upperBound = 10;
        const int iterations = 1000;

        for (int i = 0; i < iterations; i++)
        {
            int result = random.randint(lowerBound, upperBound);
            Assert.IsTrue(result >= lowerBound && result <= upperBound);
        }
    }

    [Test]
    public void Choice_WhenSeqIsEmpty_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => random.choice(new List<int>()));
    }

    [Test]
    public void Choice_ReturnsElementFromSeq()
    {
        List<int> seq = new List<int> { 1, 2, 3, 4, 5 };
        const int iterations = 1000;

        for (int i = 0; i < iterations; i++)
            Assert.IsTrue(seq.Contains(random.choice(seq)));
    }

    [Test]
    public void Shuffle_ReturnsShuffledList()
    {
        List<int> original = new List<int> { 1, 2, 3, 4, 5 };
        List<int> shuffled = new List<int>(original);

        random.shuffle(shuffled);

        Assert.AreNotEqual(original, shuffled);
        CollectionAssert.AreEquivalent(original, shuffled);
    }

    [Test]
    public void Random_GeneratesNumberWithinRange()
    {
        const int iterations = 1000;

        for (int i = 0; i < iterations; i++)
        {
            double result = random.Random();
            Assert.IsTrue(result >= 0.0 && result < 1.0);
        }
    }

    [Test]
    public void Uniform_GeneratesNumberWithinRange()
    {
        const double lowerBound = 1.0;
        const double upperBound = 10.0;
        const int iterations = 1000;

        for (int i = 0; i < iterations; i++)
        {
            double result = random.uniform(lowerBound, upperBound);
            Assert.IsTrue(result >= lowerBound && result <= upperBound);
        }
    }
}
