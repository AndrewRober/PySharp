using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace PySharp
{
    public class re
    {
        /// <summary>
        /// Compiles a regular expression pattern into a Regex object.
        /// Equivalent to Python's re.compile(pattern[, flags]).
        /// </summary>
        /// <param name="pattern">The regular expression pattern to compile.</param>
        /// <param name="flags">Optional RegexOptions to customize the behavior of the compiled regex.</param>
        /// <returns>A compiled Regex object.</returns>
        /// <example>
        /// Python:
        /// import re
        /// pattern = re.compile(r'\d+')
        /// </example>
        public static Regex compile(string pattern, RegexOptions flags = RegexOptions.None) =>
            new Regex(pattern, flags);

        /// <summary>
        /// Searches the input string for the first occurrence of the specified pattern.
        /// Equivalent to Python's re.search(pattern, string[, flags]).
        /// </summary>
        /// <param name="pattern">The regular expression pattern to search for.</param>
        /// <param name="input">The string to search for the pattern in.</param>
        /// <param name="flags">Optional RegexOptions to customize the behavior of the regex search.</param>
        /// <returns>A Match object if the pattern is found, otherwise null.</returns>
        /// <example>
        /// Python:
        /// import re
        /// result = re.search(r'\d+', 'abc123def')
        /// </example>
        public static Match search(string pattern, string input, RegexOptions flags = RegexOptions.None) =>
            Regex.Match(input, pattern, flags);

        /// <summary>
        /// Determines if the regular expression pattern matches at the start of the input string.
        /// Equivalent to Python's re.match(pattern, string[, flags]).
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="input">The string to attempt to match the pattern at the start of.</param>
        /// <param name="flags">Optional RegexOptions to customize the behavior of the regex match.</param>
        /// <returns>A Match object if the pattern is found, otherwise null.</returns>
        /// <example>
        /// Python:
        /// import re
        /// result = re.match(r'\d+', '123abc')
        /// </example>
        public static Match match(string pattern, string input, RegexOptions flags = RegexOptions.None)
        {
            var match = Regex.Match(input, pattern, flags);
            return match.Success && match.Index == 0 ? match : null;
        }

        /// <summary>
        /// Replaces all occurrences of the specified pattern with the given replacement string.
        /// Equivalent to Python's re.sub(pattern, repl, string[, count[, flags]]).
        /// </summary>
        /// <param name="pattern">The regular expression pattern to search for.</param>
        /// <param name="replacement">The string to replace the pattern with.</param>
        /// <param name="input">The string to perform the search and replace operation on.</param>
        /// <param name="count">The maximum number of occurrences to replace. If count is 0, all occurrences will be replaced.</param>
        /// <param name="flags">Optional RegexOptions to customize the behavior of the regex search and replace.</param>
        /// <returns>A new string with the specified pattern replaced by the replacement string.</returns>
        /// <example>
        /// Python:
        /// import re
        /// result = re.sub(r'\d+', 'X', 'abc123def456')
        /// </example>
        public static string sub(string pattern, string repl, string input, int count = 0, RegexOptions options = RegexOptions.None)
        {
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);
            StringBuilder result = new StringBuilder(input);

            int replacements = 0;
            int offset = 0;

            foreach (Match match in matches)
            {
                if (count != 0 && replacements >= count)
                {
                    break;
                }

                result.Replace(match.Value, repl, match.Index + offset, match.Length);
                offset += repl.Length - match.Length;
                replacements++;
            }

            return result.ToString();
        }

        /// <summary>
        /// Finds all non-overlapping occurrences of the specified pattern in the input string.
        /// Equivalent to Python's re.findall(pattern, string[, flags]).
        /// </summary>
        /// <param name="pattern">The regular expression pattern to search for.</param>
        /// <param name="input">The string to search for the pattern in.</param>
        /// <param name="flags">Optional RegexOptions to customize the behavior of the regex search.</param>
        /// <returns>A list of strings containing all the non-overlapping matches.</returns>
        /// <example>
        /// Python:
        /// import re
        /// result = re.findall(r'\d+', 'abc123def456')
        public static List<string> findall(string pattern, string input, RegexOptions flags = RegexOptions.None) =>
            Regex.Matches(input, pattern, flags).Select(match => match.Value).ToList();

        /// <summary>
        /// Finds all non-overlapping occurrences of the specified pattern in the input string and returns an iterator.
        /// Equivalent to Python's re.finditer(pattern, string[, flags]).
        /// </summary>
        /// <param name="pattern">The regular expression pattern to search for.</param>
        /// <param name="input">The string to search for the pattern in.</param>
        /// <param name="flags">Optional RegexOptions to customize the behavior of the regex search.</param>
        /// <returns>An IEnumerable of Match objects for each non-overlapping match found.</returns>
        /// <example>
        /// Python:
        /// import re
        /// result = re.finditer(r'\d+', 'abc123def456')
        /// </example>
        public static IEnumerable<Match> finditer(string pattern, string input, RegexOptions flags = RegexOptions.None) =>
            Regex.Matches(input, pattern, flags).OfType<Match>();
    }
}