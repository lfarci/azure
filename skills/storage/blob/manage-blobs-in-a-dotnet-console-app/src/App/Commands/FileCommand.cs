namespace App
{
    internal class FileCommand : Command
    {
        private readonly FileGenerator _fileGenerator = new();

        public FileCommand(ConsoleApp app) : base(app)
        {
        }

        public override string Run()
        {
            if (_app.LastLineTokens.Length < 2)
            {
                return "File: missing subcommand.";
            }

            var subcommand = _app.LastLineTokens[1];

            return subcommand switch
            {
                "text" => GenerateANewTextFile(),
                _ => "File: unknown subcommand.",
            };
        }

        private string GenerateANewTextFile()
        {
            if (_app.LastLineTokens.Length < 3)
            {
                return "File: missing text file content.";
            }

            var content = string.Join(" ", _app.LastLineTokens.Skip(2));
            var path = _fileGenerator.GenerateTextFile(content);

            return $"Text file generated at {path}.";
        }
    }
}