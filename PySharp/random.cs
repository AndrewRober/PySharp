namespace PySharp
{
    using System;

    public class random
    {
        private static Random _random = new Random();

        /// <summary>
        /// Return a random integer N such that a <= N <= b.
        /// Equivalent to Python's random.randint(a, b)
        /// </summary>
        /// <param name="a">The lower bound of the range</param>
        /// <param name="b">The upper bound of the range</param>
        /// <returns>A random integer between a and b inclusive</returns>
        public static int randint(int a, int b) => _random.Next(a, b + 1);

        /// <summary>
        /// Choose a random element from a non-empty sequence.
        /// Equivalent to Python's random.choice(seq)
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence</typeparam>
        /// <param name="seq">The sequence to choose from</param>
        /// <returns>A randomly chosen element from the sequence</returns>
        /// <exception cref="ArgumentException">Thrown if the sequence is empty</exception>
        public static T choice<T>(IList<T> seq)
        {
            if (seq.Count == 0)
            {
                throw new ArgumentException("Sequence must not be empty.");
            }

            return seq[_random.Next(seq.Count)];
        }

        /// <summary>
        /// Shuffle the sequence x in place.
        /// Equivalent to Python's random.shuffle(x[, random])
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence</typeparam>
        /// <param name="x">The sequence to shuffle</param>
        public static void shuffle<T>(IList<T> x)
        {
            int n = x.Count;
            while (n > 1)
            {
                int k = _random.Next(n--);
                T temp = x[n];
                x[n] = x[k];
                x[k] = temp;
            }
        }

        /// <summary>
        /// Return the next random floating point number in the range [0.0, 1.0).
        /// Equivalent to Python's random.random()
        /// </summary>
        /// <returns>A random floating point number in the range [0.0, 1.0)</returns>
        public static double Random() => _random.NextDouble();

        /// <summary>
        /// Return a random floating point number N such that a <= N <= b.
        /// Equivalent to Python's random.uniform(a, b)
        /// </summary>
        /// <param name="a">The lower bound of the range</param>
        /// <param name="b">The upper bound of the range</param>
        /// <returns>A random floating point number between a and b inclusive</returns>
        public static double uniform(double a, double b) => a + _random.NextDouble() * (b - a);
    }
}