using App;

new ConsoleApp(ConfigurationReader.Read()).Start();

internal class FileGenerator
{
    private readonly string _workingDirectory;

    public FileGenerator(string workingDirectory)
    {
        _workingDirectory = workingDirectory;
    }

    public FileGenerator() : this(Path.GetTempPath())
    {
    }

    public string GenerateFile(string fileName, string content)
    {
        var filePath = Path.Combine(_workingDirectory, fileName);

        if (File.Exists(filePath))
        {
            Console.WriteLine($"File {fileName} already exists.");
            return filePath;
        }

        File.WriteAllText(filePath, content);

        Console.WriteLine($"File {fileName} created.");

        return filePath;
    }
}
