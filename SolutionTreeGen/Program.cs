class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: dotnet YourApplicationName.dll <solutionPath> [/F] [/A]");
            Console.WriteLine("/F: Print folders and files.");
            Console.WriteLine("/A: Exclude files and folders inside any bin and obj folders.");
            return;
        }

        string solutionPath = args[0];
        bool printFiles = false;
        bool excludeRuntimeObjects = false;

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i].Equals("/F", StringComparison.OrdinalIgnoreCase))
            {
                printFiles = true;
            }
            else if (args[i].Equals("/A", StringComparison.OrdinalIgnoreCase))
            {
                excludeRuntimeObjects = true;
            }
        }

        if (Directory.Exists(solutionPath))
        {
            PrintFolderTree(solutionPath, "", printFiles, excludeRuntimeObjects);
        }
        else
        {
            Console.WriteLine("The provided path does not exist.");
        }
    }

    static void PrintFolderTree(string path, string indent, bool printFiles, bool excludeRuntimeObjects)
    {
        if (excludeRuntimeObjects && (path.EndsWith("bin") || path.EndsWith("obj")))
        {
            return;
        }

        if (Path.GetFileName(path).StartsWith("."))
        {
            return;
        }

        Console.WriteLine($"{indent}- {Path.GetFileName(path)}");

        string newIndent = indent + "  ";

        foreach (var directory in Directory.GetDirectories(path))
        {
            if (!Path.GetFileName(directory).StartsWith("."))
            {
                PrintFolderTree(directory, newIndent, printFiles, excludeRuntimeObjects);
            }
        }

        if (printFiles)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                if (!Path.GetFileName(file).StartsWith("."))
                {
                    Console.WriteLine($"{newIndent}- {Path.GetFileName(file)}");
                }
            }
        }
    }
}
