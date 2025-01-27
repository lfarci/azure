using System.Text;

namespace App
{
    internal class ContainerCommand : Command
    {
        public ContainerCommand(ConsoleApp app) : base(app)
        {
        }

        private string ListContainers()
        { 
            var names = _app.Storage.ListContainers();
            var output = new StringBuilder();

            output.AppendLine("Containers:");

            foreach (var name in names)
            {
                output.Append("- ");
                output.AppendLine(name);
            }

            output.AppendLine();

            return output.ToString();
        }

        private string CreateContainer()
        {
            if (_app.LastLineTokens.Length < 3)
            {
                return "Container: missing container name.";
            }

            var name = _app.LastLineTokens[2];

            _app.Storage.CreateContainer(name);

            return $"Container named {name} has been created successfully.";
        }

        private string DeleteContainer()
        {
            if (_app.LastLineTokens.Length < 3)
            {
                return "Container: missing container name.";
            }

            var name = _app.LastLineTokens[2];

            _app.Storage.DeleteContainer(name);
            
            return $"Container named {name} has been deleted successfully.";
        }

        private string SetContainer()
        {
            if (_app.LastLineTokens.Length < 3)
            {
                return "Container: missing container name.";
            }

            var name = _app.LastLineTokens[2];

            if (!_app.Storage.Contains(name))
            {
                return $"Container named {name} does not exist.";
            }

            _app.CurrentContainerName = name;

            return $"Current container set to {name}.";
        }

        private string UnsetContainer()
        {
            _app.CurrentContainerName = string.Empty;

            return $"Current container has been unset.";
        }

        private string ShowCurrentContainer()
        {
            if (string.IsNullOrEmpty(_app.CurrentContainerName))
            {
                return "No current container set.";
            }

            if (!_app.Storage.Contains(_app.CurrentContainerName))
            {
                return $"Current container {_app.CurrentContainerName} does not exist.";
            }

            var container = _app.Storage.GetContainer(_app.CurrentContainerName);

            if (container == null)
            {
                return $"Current container {_app.CurrentContainerName} could not be resolved.";
            }

            var properties = container.GetProperties().Value;
            var output = new StringBuilder();

            output.AppendLine($"Name: {_app.CurrentContainerName}");
            output.AppendLine($"URI: {container.Uri}");
            output.AppendLine($"Public access: {properties.PublicAccess}");
            output.AppendLine($"Last modified: {properties.LastModified}");

            return output.ToString();
        }

        public override string Run()
        {
            if (_app.LastLineTokens.Length < 2)
            {
                return "Container: missing subcommand.";
            }

            var subcommand = _app.LastLineTokens[1];

            return subcommand switch
            {
                "list" => ListContainers(),
                "create" => CreateContainer(),
                "delete" => DeleteContainer(),
                "set" => SetContainer(),
                "unset" => UnsetContainer(),
                "show" => ShowCurrentContainer(),
                _ => "Container: unknown subcommand.",
            };
        }
    }
}