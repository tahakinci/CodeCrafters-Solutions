class Program
{
    static void Main()
    {
        bool isTerminated = false;
        string[] builtInCommands = ["exit", "echo", "type"];
        while(!isTerminated)
        {
            Console.Write("$ ");
            var input = Console.ReadLine();

            var parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = parts.First();
            string restText = string.Join(" ", parts.Skip(1));
            switch (command)
            {
                case "exit":
                    return;
                case "echo":
                    Console.WriteLine(restText);
                    break;
                case "type": 
                    
                    if(builtInCommands.Any(c => c == restText)) {
                        Console.WriteLine($"{restText} is a shell builtin");
                        break;
                    }
var paths = Environment.GetEnvironmentVariable("PATH")
    ?.Split(';', StringSplitOptions.RemoveEmptyEntries)
    ?? Array.Empty<string>();

var pathExts = Environment.GetEnvironmentVariable("PATHEXT")
    ?.Split(';', StringSplitOptions.RemoveEmptyEntries)
    ?? new[] { "" }; 

                    foreach (var path in paths)
                    {
                        
                        foreach (var ext in pathExts)
                        {
                            var fullPath = Path.Combine(path, restText + ext);
                            Console.WriteLine(fullPath);
                            if(File.Exists(fullPath))
                            {
                                Console.WriteLine($"{restText} is {fullPath}");
                            }
                        }

                    }

                    Console.WriteLine($"{restText}: not found");
                    break;
                default:
                    Console.WriteLine($"{command}: command not found");
                    break;
            }
        }
    }
}
