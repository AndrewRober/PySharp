namespace PySharp
{
    /// <summary>
    /// The TypeConverters class provides a set of static methods that mimic
    /// Python's native type conversion functions, such as float(), int(), chr(), and bool().
    /// These methods allow you to convert input objects to the corresponding data types,
    /// following Python's conventions and behavior.
    /// 
    /// The class contains the following methods:
    ///   - @float: Converts a given object to a floating-point number.
    ///   - @int: Converts a given object to an integer.
    ///   - @chr: Converts a given integer to a character.
    ///   - @bool: Converts a given object to a boolean.
    ///   
    /// Usage examples, error handling, and edge cases are documented within each method's
    /// individual summary comment block.
    /// </summary>
    public static class TypeConverters
    {
        /// <summary>
        /// Converts a given object to a floating-point number.
        /// </summary>
        /// <param name="x">The input object to be converted to a float.</param>
        /// <returns>A floating-point number converted from the input object.</returns>
        /// <exception cref="FormatException">Thrown when the input object cannot be converted to a float.</exception>
        /// <example>
        /// Python equivalent:
        ///   float(3)
        ///   float("3.14")
        /// </example>
        public static float @float(object x)
        {
            if (x == null) return 0.0f;
            try
            {
                return Convert.ToSingle(x);
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
            {
                throw new FormatException($"Cannot convert object of type '{x.GetType().Name}' to float.");
            }
        }

        /// <summary>
        /// Converts a given object to an integer.
        /// </summary>
        /// <param name="x">The input object to be converted to an integer.</param>
        /// <param name="base">The base of the number represented by x (optional, default is 10).</param>
        /// <returns>An integer converted from the input object.</returns>
        /// <exception cref="FormatException">Thrown when the input object cannot be converted to an integer.</exception>
        /// <example>
        /// Python equivalent:
        ///   int(3.14)
        ///   int("42")
        ///   int("1010", 2)
        /// </example>
        public static int @int(object x, int @base = 10)
        {
            if (x == null) return 0;

            try
            {
                if (x is string s) return Convert.ToInt32(s, @base);
                return Convert.ToInt32(x);
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidCastException || ex is OverflowException)
            {
                throw new FormatException($"Cannot convert object of type '{x.GetType().Name}' to int.");
            }
        }

        /// <summary>
        /// Converts a given integer to a character.
        /// </summary>
        /// <param name="i">The integer to be converted to a character.</param>
        /// <returns>A character represented by the input integer's Unicode code point.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the input integer is not a valid Unicode code point.</exception>
        /// <example>
        /// Python equivalent:
        ///   chr(65)
        /// </example>
        public static char chr(int i)
        {
            if (i < 0 || i > 0x10FFFF)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Invalid Unicode code point.");
            }
            return Convert.ToChar(i);
        }

        /// <summary>
        /// Converts a given object to a boolean.
        /// </summary>
        /// <param name="x">The input object to be converted to a boolean.</param>
        /// <returns>A boolean value converted from the input object.</returns>
        /// <example>
        /// Python equivalent:
        ///   bool(0)
        ///   bool(42)
        ///   bool("")
        ///   bool("Hello, World!")
        /// </example>
        public static bool @bool(object x) =>
            x switch
            {
                null => false,
                bool b => b,
                string s => !string.IsNullOrEmpty(s),
                IConvertible c => c.ToBoolean(null),
                _ => true
            };
    }
}