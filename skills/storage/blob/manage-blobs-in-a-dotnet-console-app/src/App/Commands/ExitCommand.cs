namespace App
{
    internal class ExitCommand : Command
    {
        public ExitCommand(ConsoleApp app) : base(app)
        {
        }

        public override string Run()
        {
            _app.Stop();

            return "Bye!";
        }
    }
}
