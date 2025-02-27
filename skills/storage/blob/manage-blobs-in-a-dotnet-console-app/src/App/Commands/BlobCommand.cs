﻿
using System.Text;

namespace App
{
    internal class BlobCommand : Command
    {
        public BlobCommand(ConsoleApp app) : base(app)
        {
        }

        public override string Run()
        {
            if (_app.LastLineTokens.Length < 2)
            {
                return "Blob: missing subcommand.";
            }

            if (string.IsNullOrEmpty(_app.CurrentContainerName))
            {
                return "Blob: no container selected.";
            }

            var subcommand = _app.LastLineTokens[1];

            return subcommand switch
            {
                "list" => ListBlobs(),
                "upload" => UploadBlob(),
                "download" => DownloadBlob(),
                "delete" => DeleteBlob(),
                "dir" => SetDownloadDirectory(),
                _ => "Blob: unknown subcommand.",
            };
        }

        private string SetDownloadDirectory()
        {
            if (_app.LastLineTokens.Length < 3)
            {
                return "Blob: missing download directory.";
            }

            _app.DownloadDirectory = _app.LastLineTokens[2];

            return $"Download directory set to {_app.DownloadDirectory}.";
        }

        private string DeleteBlob()
        {
            var container = _app.Storage.GetContainer(_app.CurrentContainerName);

            if (_app.LastLineTokens.Length < 3)
            {
                return "Blob: missing blob name.";
            }

            var name = _app.LastLineTokens[2];

            container.DeleteBlob(name);

            return $"Blob named {name} has been deleted successfully.";
        }

        private string DownloadBlob()
        {
            var container = _app.Storage.GetContainer(_app.CurrentContainerName);

            if (_app.LastLineTokens.Length < 3)
            {
                return "Blob: missing blob name.";
            }

            var name = _app.LastLineTokens[2];
            var targetPath = Path.Combine(_app.DownloadDirectory, name);

            container.GetBlobClient(name).DownloadTo(targetPath);

            return $"Blob named {name} has been downloaded successfully at {targetPath}.";
        }

        private string UploadBlob()
        {
            var container = _app.Storage.GetContainer(_app.CurrentContainerName);

            if (_app.LastLineTokens.Length < 3)
            {
                return "Blob: missing blob name.";
            }

            var path = _app.LastLineTokens[2];
            var fileName = Path.GetFileName(path);
            var blob = container.GetBlobClient(fileName);

            using (var stream = File.OpenRead(path))
            {
                blob.Upload(stream);
            }

            return $"Blob named {fileName} has been uploaded successfully.";
        }

        private string ListBlobs()
        {
            var container = _app.Storage.GetContainer(_app.CurrentContainerName);
            var output = new StringBuilder();

            output.AppendLine("Blobs:");

            foreach (var blob in container.GetBlobs())
            {
                output.Append("- ");
                output.AppendLine(blob.Name);
            }

            return output.ToString();
        }
    }
}