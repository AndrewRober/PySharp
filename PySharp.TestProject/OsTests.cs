using PySharp;

[TestFixture]
public class OsTests
{
    private const string TestDirectory = "test_directory";
    private const string TestFile = "test_file.txt";
    private const string TestFileFullPath = TestDirectory + "\\" + TestFile;

    // os.makedirs tests
    [Test]
    public void Makedirs_WhenNameIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.makedirs(null));
    }

    [Test]
    public void Makedirs_WhenNameIsEmpty_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => os.makedirs(""));
    }

    [Test]
    public void Makedirs_WhenNameIsWhitespace_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => os.makedirs("  "));
    }

    [Test]
    public void Makedirs_CreatesDirectory()
    {
        os.makedirs(TestDirectory);
        Assert.IsTrue(Directory.Exists(TestDirectory));

        // Clean up
        Directory.Delete(TestDirectory);
    }

    // os.remove tests
    [Test]
    public void Remove_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.remove(null));
    }

    [Test]
    public void Remove_WhenFileNotExists_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => os.remove(TestFile));
    }

    [Test]
    public void Remove_DeletesFile()
    {
        // Create a test file
        Directory.CreateDirectory(TestDirectory);
        File.WriteAllText(TestFileFullPath, "test content");

        os.remove(TestFileFullPath);
        Assert.IsFalse(File.Exists(TestFileFullPath));

        // Clean up
        Directory.Delete(TestDirectory);
    }

    // os.path.join tests
    [Test]
    public void PathJoin_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.join(null, "file"));
    }

    [Test]
    public void PathJoin_WhenPathsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.join("path", null));
    }

    [Test]
    public void PathJoin_CreatesCombinedPath()
    {
        string result = os.path.join("dir1", "dir2", "file.txt");
        Assert.AreEqual("dir1\\dir2\\file.txt", result);
    }

    // os.path.abspath tests
    [Test]
    public void PathAbspath_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.abspath(null));
    }

    [Test]
    public void PathAbspath_TransformsRelativeToAbsolute()
    {
        string result = os.path.abspath("test");
        Assert.AreEqual(Path.GetFullPath("test"), result);
    }

    // os.path.exists tests
    [Test]
    public void PathExists_WhenPathIsNull_ReturnsFalse()
    {
        Assert.IsFalse(os.path.exists(null));
    }

    [Test]
    public void PathExists_WhenPathIsEmpty_ReturnsFalse()
    {
        Assert.IsFalse(os.path.exists(""));
    }

    [Test]
    public void PathExists_WhenPathIsFile_ReturnsTrue()
    {
        // Create a test file
        Directory.CreateDirectory(TestDirectory);
        File.WriteAllText(TestFileFullPath, "test content");

        Assert.IsTrue(os.path.exists(TestFileFullPath));

        // Clean up
        File.Delete(TestFileFullPath);
        Directory.Delete(TestDirectory);
    }

    [Test]
    public void PathExists_WhenPathIsDirectory_ReturnsTrue()
    {
        // Create a test directory
        Directory.CreateDirectory(TestDirectory);

        Assert.IsTrue(os.path.exists(TestDirectory));

        // Clean up
        Directory.Delete(TestDirectory);
    }

    // os.path.basename tests
    [Test]
    public void PathBasename_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.basename(null));
    }

    [Test]
    public void PathBasename_ReturnsBaseName()
    {
        string result = os.path.basename("dir1\\dir2\\file.txt");
        Assert.AreEqual("file.txt", result);
    }

    // os.path.dirname tests
    [Test]
    public void PathDirname_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.dirname(null));
    }

    [Test]
    public void PathDirname_ReturnsDirectoryName()
    {
        string result = os.path.dirname("dir1\\dir2\\file.txt");
        Assert.AreEqual("dir1\\dir2", result);
    }

    // os.path.splitext tests
    [Test]
    public void PathSplitext_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.splitext(null));
    }

    [Test]
    public void PathSplitext_SplitsExtension()
    {
        (string root, string ext) = os.path.splitext("file.txt");
        Assert.AreEqual("file", root);
        Assert.AreEqual(".txt", ext);
    }

    // os.path.isfile tests
    [Test]
    public void PathIsfile_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.isfile(null));
    }

    [Test]
    public void PathIsfile_WhenPathIsFile_ReturnsTrue()
    {
        // Create a test file
        Directory.CreateDirectory(TestDirectory);
        File.WriteAllText(TestFileFullPath, "test content");

        Assert.IsTrue(os.path.isfile(TestFileFullPath));

        // Clean up
        File.Delete(TestFileFullPath);
        Directory.Delete(TestDirectory);
    }

    [Test]
    public void PathIsfile_WhenPathIsDirectory_ReturnsFalse()
    {
        // Create a test directory
        Directory.CreateDirectory(TestDirectory);

        Assert.IsFalse(os.path.isfile(TestDirectory));

        // Clean up
        Directory.Delete(TestDirectory);
    }

    // os.path.isdir tests
    [Test]
    public void PathIsdir_WhenPathIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => os.path.isdir(null));
    }

    [Test]
    public void PathIsdir_WhenPathIsFile_ReturnsFalse()
    {
        // Create a test file
        Directory.CreateDirectory(TestDirectory);
        File.WriteAllText(TestFileFullPath, "test content");

        Assert.IsFalse(os.path.isdir(TestFileFullPath));

        // Clean up
        File.Delete(TestFileFullPath);
        Directory.Delete(TestDirectory);
    }

    [Test]
    public void PathIsdir_WhenPathIsDirectory_ReturnsTrue()
    {
        // Create a test directory
        Directory.CreateDirectory(TestDirectory);

        Assert.IsTrue(os.path.isdir(TestDirectory));

        // Clean up
        Directory.Delete(TestDirectory);
    }
}
