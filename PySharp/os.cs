namespace PySharp
{
    using System;
    using System.IO;

    public static class os
    {

        /// <summary>
        /// Create a new directory at the specified path.
        /// </summary>
        /// <param name="name">The directory path to be created.</param>
        /// <example>
        /// C#: os.makedirs("path/to/new/directory");
        /// Python: os.makedirs("path/to/new/directory")
        /// </example>
        public static void makedirs(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Path is empty.", nameof(name));
            }

            Directory.CreateDirectory(name);
        }

        /// <summary>
        /// Remove a file at the specified path.
        /// </summary>
        /// <param name="path">The file path to be removed.</param>
        /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
        /// <example>
        /// C#: os.remove("path/to/file.txt");
        /// Python: os.remove("path/to/file.txt")
        /// </example>
        public static void remove(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }
            File.Delete(path);
        }

        public static class path
        {
            /// <summary>
            /// Join one or more pathname components into a single path.
            /// </summary>
            /// <param name="path">The first path component.</param>
            /// <param name="paths">Additional path components.</param>
            /// <returns>A string representing the combined path.</returns>
            /// <example>
            /// C#: os.path.join("folderA", "folderB", "file.txt");
            /// Python: os.path.join("folderA", "folderB", "file.txt")
            /// </example>
            public static string join(string path, params string[] paths)
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                if (paths == null)
                {
                    throw new ArgumentNullException(nameof(paths));
                }
                return Path.Combine(path, Path.Combine(paths));
            }

            /// <summary>
            /// Return the absolute version of a pathname.
            /// </summary>
            /// <param name="path">The input path to be converted to an absolute path.</param>
            /// <returns>A string representing the absolute path.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
            /// <example>
            /// C#: os.path.abspath("relative/path/to/file.txt");
            /// Python: os.path.abspath("relative/path/to/file.txt")
            /// </example>
            public static string abspath(string path)
            {
                if (path == null)
                    throw new ArgumentNullException(nameof(path));
                return Path.GetFullPath(path);
            }

            /// <summary>
            /// Test whether a path exists.
            /// </summary>
            /// <param name="path">The input path to be checked for existence.</param>
            /// <returns>A boolean indicating whether the path exists.</returns>
            /// <example>
            /// C#: os.path.exists("path/to/file.txt");
            /// Python: os.path.exists("path/to/file.txt")
            /// </example>
            public static bool exists(string path) => !string.IsNullOrEmpty(path) && (File.Exists(path) || Directory.Exists(path));

            /// <summary>
            /// Return the base name of the given path.
            /// </summary>
            /// <param name="path">The input path to extract the base name from.</param>
            /// <returns>A string representing the base name.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
            /// <example>
            /// C#: os.path.basename("path/to/file.txt");
            /// Python: os.path.basename("path/to/file.txt")
            /// </example>
            public static string basename(string path)
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                return Path.GetFileName(path);
            }

            /// <summary>
            /// Return the directory name of the given path.
            /// </summary>
            /// <param name="path">The input path to extract the directory name from.</param>
            /// <returns>A string representing the directory name.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
            /// <example>
            /// C#: os.path.dirname("path/to/file.txt");
            /// Python: os.path.dirname("path/to/file.txt")
            /// </example>
            public static string dirname(string path)
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                return Path.GetDirectoryName(path);
            }

            /// <summary>
            /// Split the pathname path into a tuple (root, ext), such that root + ext == path, and ext is empty or begins with a period and contains at most one period.
            /// </summary>
            /// <param name="path">The input path to be split into root and extension.</param>
            /// <returns>A tuple with the root and extension strings.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
            /// <example>
            /// C#: os.path.splitext("path/to/file.txt");
            /// Python: os.path.splitext("path/to/file.txt")
            /// </example>
            public static (string root, string ext) splitext(string path)
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                return (Path.GetFileNameWithoutExtension(path), Path.GetExtension(path));
            }

            /// <summary>
            /// Test whether a path is a regular file.
            /// </summary>
            /// <param name="path">The input path to be checked.</param>
            /// <returns>A boolean indicating whether the path is a file.</returns>
            /// <example>
            /// C#: os.path.isfile("path/to/file.txt");
            /// Python: os.path.isfile("path/to/file.txt")
            /// </example>
            public static bool isfile(string path)
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                return File.Exists(path);
            }

            /// <summary>
            /// Test whether a path is an existing directory.
            /// </summary>
            /// <param name="path">The input path to be checked.</param>
            /// <returns>A boolean indicating whether the path is a directory.</returns>
            /// <example>
            /// C#: os.path.isdir("path/to/directory");
            /// Python: os.path.isdir("path/to/directory")
            /// </example>
            public static bool isdir(string path)
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                return Directory.Exists(path);
            }
        }
    }
}