namespace PySharp
{
    public static class ListFunctions
    {
        /// <summary>
        /// Mimics Python's range(stop) function. Generates a sequence of integers from 0 to stop - 1.
        /// </summary>
        /// <param name="stop">The end value of the range, exclusive.</param>
        /// <returns>An IEnumerable of integers.</returns>
        /// <example>
        /// Python equivalent:
        ///   range(5)
        /// </example>
        public static IEnumerable<int> Range(int stop)
        {
            if (stop < 0)
                throw new ArgumentOutOfRangeException(nameof(stop), "Stop value must be non-negative.");

            return Enumerable.Range(0, stop);
        }

        /// <summary>
        /// Mimics Python's range(start, stop[, step]) function. Generates a sequence of 
        /// integers from start to stop - 1, with an optional step.
        /// </summary>
        /// <param name="start">The start value of the range, inclusive.</param>
        /// <param name="stop">The end value of the range, exclusive.</param>
        /// <param name="step">The optional step value to increment by (default is 1).</param>
        /// <returns>An IEnumerable of integers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when step is 0 or when the stop value is 
        /// not reachable from the start value with the given step.</exception>
        /// <example>
        /// Python equivalent:
        ///   range(1, 6)
        ///   range(1, 10, 2)
        /// </example>
        public static IEnumerable<int> Range(int start, int stop, int step = 1)
        {
            if (step == 0)
                throw new ArgumentOutOfRangeException(nameof(step), "Step value must not be zero.");

            if ((stop > start && step < 0) || (stop < start && step > 0))
                throw new ArgumentOutOfRangeException(nameof(stop),
                    "Stop value is not reachable from the start value with the given step.");

            return Enumerable.Range(start, (stop - start + step - 1) / step).Select(i => start + i * step);
        }

        /// <summary>
        /// Mimics Python's len() function. Returns the number of elements in a collection.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <returns>The number of elements in the collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   len([1, 2, 3, 4, 5])
        /// </example>
        public static int Len<T>(IEnumerable<T> collection) => collection.Count();

        /// <summary>
        /// Mimics Python's min() function. Returns the minimum element in a collection.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <returns>The minimum element in the collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the input collection is empty.</exception>
        /// <example>
        /// Python equivalent:
        ///   min([1, 2, 3, 4, 5])
        /// </example>
        public static TSource Min<TSource>(IEnumerable<TSource> collection) => collection.Min();

        /// <summary>
        /// Mimics Python's max() function. Returns the maximum element in a collection.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <returns>The maximum element in the collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the input collection is empty.</exception>
        /// <example>
        /// Python equivalent:
        ///   max([1, 2, 3, 4, 5])
        /// </example>
        public static TSource Max<TSource>(IEnumerable<TSource> collection) => collection.Max();

        /// <summary>
        /// Mimics Python's sum() function. Returns the sum of all elements in a collection.
        /// </summary>
        /// <param name="collection">The input collection of integers.</param>
        /// <returns>The sum of all elements in the collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   sum([1, 2, 3, 4, 5])
        /// </example>
        public static int Sum(IEnumerable<int> collection) => collection.Sum();

        /// <summary>
        /// Mimics Python's enumerate() function. Returns an IEnumerable of tuples containing 
        /// the index and value of each element in the input collection.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <returns>An IEnumerable of tuplescontaining the index and value of each element in the input collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   list(enumerate(["a", "b", "c"]))
        /// </example>
        public static IEnumerable<(int, TSource)> Enumerate<TSource>(IEnumerable<TSource> collection) => 
            collection.Select((value, index) => (index, value));

        /// <summary>
        /// Mimics Python's zip() function. Takes two input collections and returns an IEnumerable 
        /// of tuples containing pairs of elements with the same index from each collection.
        /// </summary>
        /// <param name="collection1">The first input collection.</param>
        /// <param name="collection2">The second input collection.</param>
        /// <returns>An IEnumerable of tuples containing pairs of elements with the same index from each collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   list(zip([1, 2, 3], ["a", "b", "c"]))
        /// </example>
        public static IEnumerable<(TSource1, TSource2)> Zip<TSource1, TSource2>(IEnumerable<TSource1> collection1,
            IEnumerable<TSource2> collection2) => collection1.Zip(collection2, (a, b) => (a, b));

        /// <summary>
        /// Mimics Python's reversed() function. Returns a reversed copy of the input collection.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <returns>A reversed copy of the input collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   list(reversed([1, 2, 3, 4, 5]))
        /// </example>
        public static IEnumerable<TSource> Reversed<TSource>(IEnumerable<TSource> collection) => collection.Reverse();

        /// <summary>
        /// Mimics Python's sorted() function. Returns a sorted copy of the input collection using the default comparer.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <returns>A sorted copy of the input collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   sorted([3, 1, 4, 1, 5, 9, 2, 6, 5])
        /// </example>
        public static IEnumerable<TSource> Sorted<TSource>(IEnumerable<TSource> collection) => collection.OrderBy(x => x);

        /// <summary>
        /// Mimics Python's sorted() function with a key function. Returns a sorted copy of the input 
        /// collection using the specified key selector.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>A sorted copy of the input collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   sorted(["apple", "banana", "cherry"], key=len)
        /// </example>
        public static IEnumerable<TSource> Sorted<TSource, TKey>(IEnumerable<TSource> collection, 
            Func<TSource, TKey> keySelector) => collection.OrderBy(keySelector);

        /// <summary>
        /// Mimics Python's all() function. Returns true if all elements of the input collection 
        /// satisfy the specified predicate, otherwise false.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>True if all elements of the input collection satisfy the specified predicate, otherwise false.</returns>
        /// <example>
        /// Python equivalent:
        ///   all(x > 0 for x in [1, 2, 3, 4, 5])
        /// </example>
        public static bool All<TSource>(IEnumerable<TSource> collection, Func<TSource, 
            bool> predicate) => collection.All(predicate);
    }
}