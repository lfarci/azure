namespace App;

internal class ConsoleApp
{
    private static readonly string _prompt = "> ";

    private bool _running = true;
    private string _lastLine = string.Empty;
    private readonly Configuration _configuration;
    private readonly BlobStorage _blobStorage;

    public ConsoleApp(Configuration configuration)
    {
        _configuration = configuration;
        _blobStorage = new BlobStorage(configuration);
    }

    public string[] LastLineTokens => _lastLine.Split(' ');
    public BlobStorage Storage => _blobStorage;

    public string CurrentContainerName { get; internal set; } = string.Empty;

    private Command? Prompt()
    {
        if (string.IsNullOrEmpty(CurrentContainerName))
        { 
            Console.Write(_prompt);
        }
        else
        {
            Console.Write($"{CurrentContainerName} {_prompt}");
        }

        _lastLine = Console.ReadLine() ?? string.Empty;
        
        if (string.IsNullOrWhiteSpace(_lastLine))
        {
            return null;
        }

        return new Commands(this).Get();
    }

    public void Start()
    {
        while (_running)
        {
            var command = Prompt();

            if (command is null)
            {
                break;
            }

            Console.WriteLine(command.Run());
        }
    }

    public void Stop()
    {
        _running = false;
    }
}
