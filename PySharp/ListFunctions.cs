namespace PySharp
{
    using System;

    /// <summary>
    /// The ListFunctions class provides a collection of static methods that mimic Python's built-in functions
    /// and standard library methods for working with lists and other collections. These methods include common
    /// operations such as slicing, filtering, mapping, and reducing, as well as more advanced operations like
    /// itertools-style functions for working with iterators and sequences.
    ///
    /// The primary goal of this class is to provide C# developers with a familiar set of tools for working with
    /// collections, inspired by the simplicity and expressiveness of Python's built-in functions and standard
    /// library. By using these methods, developers can write more concise and readable code, similar to the
    /// way they would in Python.
    ///
    /// Note that while these methods aim to provide similar functionality to their Python counterparts, there
    /// may be differences in behavior or performance due to the differences in language features and runtime
    /// environments. Users are advised to refer to the documentation for each method to understand its usage
    /// and any potential caveats.
    /// </summary>
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
        public static IEnumerable<int> range(int stop)
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
        public static IEnumerable<int> range(int start, int stop, int step = 1)
        {
            if (step == 0)
                throw new ArgumentOutOfRangeException(nameof(step), "Step value must not be zero.");

            if ((stop > start && step < 0) || (stop < start && step > 0))
                throw new ArgumentOutOfRangeException(nameof(stop),
                    "Stop value is not reachable from the start value with the given step.");

            for (int i = start; i < stop; i += step)
            {
                yield return i;
            }
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
        public static int len<T>(IEnumerable<T> collection) => collection.Count();

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
        public static TSource min<TSource>(IEnumerable<TSource> collection) => collection.Min();

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
        public static TSource max<TSource>(IEnumerable<TSource> collection) => collection.Max();

        /// <summary>
        /// Mimics Python's sum() function. Returns the sum of all elements in a collection.
        /// </summary>
        /// <param name="collection">The input collection of integers.</param>
        /// <returns>The sum of all elements in the collection.</returns>
        /// <example>
        /// Python equivalent:
        ///   sum([1, 2, 3, 4, 5])
        /// </example>
        public static int sum(IEnumerable<int> collection) => collection.Sum();

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
        public static IEnumerable<(int, TSource)> enumerate<TSource>(IEnumerable<TSource> collection) =>
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
        public static IEnumerable<(TSource1, TSource2)> zip<TSource1, TSource2>(IEnumerable<TSource1> collection1,
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
        public static IEnumerable<TSource> reversed<TSource>(IEnumerable<TSource> collection) => collection.Reverse();

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
        public static bool all<TSource>(IEnumerable<TSource> collection, Func<TSource,
            bool> predicate) => collection.All(predicate);

        /// <summary>
        /// Mimics Python's filter() function. Filters elements from a collection based on a predicate function.
        /// </summary>
        /// <param name="predicate">A function to test each element in the collection for a condition.</param>
        /// <param name="collection">The input collection.</param>
        /// <returns>An IEnumerable containing elements of the input collection that satisfy the predicate function.</returns>
        /// <example>
        /// Python equivalent:
        ///   list(filter(lambda x: x > 0, [-1, 0, 1, 2, 3, 4, 5]))
        /// </example>
        public static IEnumerable<TSource> filter<TSource>(Func<TSource, bool> predicate,
            IEnumerable<TSource> collection) => collection.Where(predicate);

        /// <summary>
        /// Mimics Python's itertools.compress() function. 
        /// Filters elements from a collection based on a corresponding sequence of boolean values.
        /// </summary>
        /// <param name="collection">The input collection.</param>
        /// <param name="selectors">A sequence of boolean values used to filter the input collection.</param>
        /// <returns>An IEnumerable containing elements of the input collection where the corresponding selector value is true.</returns>
        /// <example>
        /// Python equivalent:
        ///   import itertools
        ///   list(itertools.compress([1, 2, 3, 4, 5], [True, False, True, False, True]))
        /// </example>
        public static IEnumerable<TSource> compress<TSource>(IEnumerable<TSource> collection, IEnumerable<bool> selectors) =>
            collection.Zip(selectors,
                (value, selector) => (value, selector))
                .Where(pair => pair.selector).Select(pair => pair.value);

        /// <summary>
        /// Mimics Python's itertools.dropwhile() function. Drops elements from the input collection while a predicate function is true, then returns the remaining elements.
        /// </summary>
        /// <param name="predicate">A function to test each element in the collection for a condition.</param>
        /// <param name="collection">The input collection.</param>
        /// <returns>An IEnumerable containing the remaining elements in the input collection after the predicate function returns false.</returns>
        /// <example>
        /// Python equivalent:
        ///   import itertools
        ///   list(itertools.dropwhile(lambda x: x < 3, [1, 2, 3, 4, 5]))
        /// </example>
        public static IEnumerable<TSource> DropWhile<TSource>(Func<TSource, bool> predicate,
            IEnumerable<TSource> collection) => collection.SkipWhile(predicate);

        /// <summary>
        /// Returns a new sorted list from the elements of the given collection in ascending or descending order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the collection.</typeparam>
        /// <param name="collection">The input collection to be sorted.</param>
        /// <param name="reverse">A boolean indicating whether the result should be sorted in descending order. Optional, default is false.</param>
        /// <returns>An IEnumerable of sorted elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the collection is null.</exception>
        /// <example>
        /// C#: Py.sorted(new List&lt;int&gt; { 5, 3, 1, 2, 4 }, reverse: true);
        /// Python: sorted([5, 3, 1, 2, 4], reverse=True)
        /// </example>
        public static IEnumerable<TSource> sorted<TSource>(IEnumerable<TSource> collection, bool reverse = false)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return reverse ? collection.OrderByDescending(x => x) : collection.OrderBy(x => x);
        }

        /// <summary>
        /// Returns a new sorted list from the elements of the given collection based on a key selector function, in ascending or descending order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the collection.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the keySelector function.</typeparam>
        /// <param name="collection">The input collection to be sorted.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="reverse">A boolean indicating whether the result should be sorted in descending order. Optional, default is false.</param>
        /// <returns>An IEnumerable of sorted elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the collection or the keySelector function is null.</exception>
        /// <example>
        /// C#: Py.sorted(new List&lt;string&gt; { "apple", "banana", "cherry" }, x => x.Length, reverse: true);
        /// Python: sorted(["apple", "banana", "cherry"], key=len, reverse=True)
        /// </example>
        public static IEnumerable<TSource> sorted<TSource, TKey>(IEnumerable<TSource> collection, Func<TSource, TKey> keySelector, bool reverse = false)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            return reverse ? collection.OrderByDescending(keySelector) : collection.OrderBy(keySelector);
        }
    }
}