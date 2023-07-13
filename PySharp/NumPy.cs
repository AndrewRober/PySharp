namespace PySharp
{
    public static class NumPy
    {
        /// <summary>
        /// Creates a new array from the specified object.
        /// </summary>
        /// <param name="data">The input object, usually a multidimensional array or a jagged array.</param>
        /// <returns>A new array.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.array([[1, 2, 3], [4, 5, 6]])
        /// </example>
        public static Array Array(object data) => data as Array;

        /// <summary>
        /// Creates a new array of the specified shape, filled with zeros.
        /// </summary>
        /// <param name="shape">The shape of the new array, specified as an array of integers.</param>
        /// <returns>A new array filled with zeros.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.zeros((3, 3))
        /// </example>
        public static Array Zeros(params int[] shape) => CreateArrayWithConstantValue(0.0, shape);

        /// <summary>
        /// Creates a new array of the specified shape, filled with ones.
        /// </summary>
        /// <param name="shape">The shape of the new array, specified as an array of integers.</param>
        /// <returns>A new array filled with ones.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.ones((3, 3))
        /// </example>
        public static Array Ones(params int[] shape) => CreateArrayWithConstantValue(1.0, shape);

        /// <summary>
        /// Creates a new array with the specified shape, filled with a constant value.
        /// </summary>
        /// <param name="value">The constant value to fill the array with.</param>
        /// <param name="shape">The shape of the new array, specified as an array of integers.</param>
        /// <returns>A new array filled with the specified constant value.</returns>
        private static Array CreateArrayWithConstantValue(double value, int[] shape)
        {
            if (shape == null || shape.Length == 0)
            {
                throw new ArgumentException("Shape must be provided and cannot be empty.", nameof(shape));
            }

            Array result = System.Array.CreateInstance(typeof(double), shape);
            for (int i = 0; i < result.Length; i++)
                result.SetValue(value, GetIndicesFromIndex(result, i));

            return result;
        }

        /// <summary>
        /// Returns the indices of the specified linear index in the given array.
        /// </summary>
        /// <param name="array">The input array.</param>
        /// <param name="index">The linear index.</param>
        /// <returns>An array of integers representing the indices.</returns>
        private static int[] GetIndicesFromIndex(Array array, int index)
        {
            int[] indices = new int[array.Rank];
            for (int i = array.Rank - 1; i >= 0; i--)
            {
                indices[i] = index % array.GetLength(i);
                index /= array.GetLength(i);
            }

            return indices;
        }

        /// <summary>
        /// Creates a new array with evenly spaced values between the specified start and stop values.
        /// </summary>
        /// <param name="start">The start value of the sequence.</param>
        /// <param name="stop">The end value of the sequence, unless endpoint is set to false.</param>
        /// <param name="step">The step size between the values (default is 1).</param>
        /// <example>
        /// Python equivalent:
        ///   numpy.arange(0, 10, 2)
        /// </example>
        public static double[] Arange(double start, double stop, double step = 1)
        {
            if (step == 0)
            {
                throw new ArgumentException("Step must be non-zero.", nameof(step));
            }

            int count = (int)Math.Ceiling((stop - start) / step);
            return Enumerable.Range(0, count).Select(i => start + i * step).ToArray();
        }

        /// <summary>
        /// Creates a new array with a specified number of evenly spaced values between the start and stop values.
        /// </summary>
        /// <param name="start">The start value of the sequence.</param>
        /// <param name="stop">The end value of the sequence, unless endpoint is set to false.</param>
        /// <param name="num">The number of evenly spaced values to generate (default is 50).</param>
        /// <param name="endpoint">If true, the stop value is included in the output (default is true).</param>
        /// <example>
        /// Python equivalent:
        ///   numpy.linspace(0, 1, 5)
        /// </example>
        public static double[] Linspace(double start, double stop, int num = 50, bool endpoint = true)
        {
            if (num <= 0)
            {
                throw new ArgumentException("Num must be positive.", nameof(num));
            }

            double step = (stop - start) / (endpoint ? num - 1 : num);
            return Enumerable.Range(0, num).Select(i => start + i * step).ToArray();
        }

        /// <summary>
        /// Computes the dot product of two arrays.
        /// </summary>
        /// <param name="a">The first input array.</param>
        /// <param name="b">The second input array.</param>
        /// <returns>The dot product of the input arrays.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.dot([1, 2, 3], [4, 5, 6])
        /// </example>
        public static double Dot(double[] a, double[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException("Input arrays must have the same length.");
            }

            return a.Zip(b, (x, y) => x * y).Sum();
        }

        /// <summary>
        /// Reshapes an array without changing its data.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <param name="newShape">The new shape of the array.</param>
        /// <returns>A reshaped array.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.reshape([[1, 2, 3], [4, 5, 6]], (3, 2))
        /// </example>
        public static Array Reshape(Array a, params int[] newShape)
        {
            if (a.Length != newShape.Aggregate(1, (acc, x) => acc * x))
            {
                throw new ArgumentException("New shape must have the same number of elements as the original array.");
            }

            Array result = System.Array.CreateInstance(typeof(double), newShape);
            for (int i = 0; i < a.Length; i++)
            {
                int[] srcIndices = GetIndicesFromIndex(a, i);
                int[] destIndices = GetIndicesFromIndex(result, i);
                result.SetValue(a.GetValue(srcIndices), destIndices);
            }

            return result;
        }

        /// <summary>
        /// Computes the sum of the elements in the input array.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <returns>The sum of the elements in the array.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.sum([1, 2, 3, 4, 5])
        /// </example>
        public static double Sum(double[] a)
        {
            return a.Sum();
        }

        /// <summary>
        /// Computes the mean of the elements in the input array.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <returns>The mean of the elements in the array.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.mean([1, 2, 3, 4, 5])
        /// </example>
        public static double Mean(double[] a)
        {
            if (a.Length == 0)
            {
                throw new ArgumentException("Input array must not be empty.", nameof(a));
            }

            return a.Average();
        }

        /// <summary>
        /// Computes the standard deviation of the elements in the input array.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <param name="ddof">Delta degrees of freedom (default is 0).</param>
        /// <returns>The standard deviation of the elements in the array.</returns>
        /// <example>
        /// Python equivalent:
        ///   numpy.std([1, 2, 3, 4, 5])
        /// </example>
        public static double Std(double[] a, int ddof = 0)
        {
            if (a.Length <= ddof)
            {
                throw new ArgumentException("Degrees of freedom must be less than the size of the input array.", nameof(ddof));
            }

            double mean = a.Average();
            double variance = a.Select(x => Math.Pow(x - mean, 2)).Sum() / (a.Length - ddof);
            return Math.Sqrt(variance);
        }


    }
}