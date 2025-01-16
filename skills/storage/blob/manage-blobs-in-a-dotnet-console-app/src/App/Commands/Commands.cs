namespace App
{
    internal class Commands
    {
        private readonly ConsoleApp _app;

        public Commands(ConsoleApp app)
        {
            this._app = app;
        }

        public Command? Get()
        {
            var tokens = _app.LastLineTokens;

            if (tokens.Length == 0)
            {
                return null;
            }

            var name = tokens[0];

            return name switch
            {
                "exit" => new ExitCommand(_app),
                "container" => new ContainerCommand(_app),
                "file" => new FileCommand(_app),
                _ => null,
            };
        }
    }
}
