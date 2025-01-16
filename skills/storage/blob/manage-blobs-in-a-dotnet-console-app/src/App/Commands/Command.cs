namespace App
{
    internal abstract class Command
    {
        protected readonly ConsoleApp _app;

        public Command(ConsoleApp app)
        {
            _app = app;
        }

        public abstract string Run();
    }
}
