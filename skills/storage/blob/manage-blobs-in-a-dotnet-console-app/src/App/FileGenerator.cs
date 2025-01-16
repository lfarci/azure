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
            return filePath;
        }

        File.WriteAllText(filePath, content);

        return filePath;
    }

    public string GenerateTextFile(string content)
    { 
        return GenerateFile($"{Guid.NewGuid()}.txt", content);
    }
}
