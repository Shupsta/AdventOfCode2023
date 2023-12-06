using Day3;

string[] commandArgs = Environment.GetCommandLineArgs();

if (commandArgs.Length < 2)
{
    Console.WriteLine($"\nError: Need at least a path for input.");
    return;
}

string inputPath = commandArgs[1];
if (!File.Exists(inputPath))
{
    Console.WriteLine($"\nError: Input file does not exist at given path.");
    return;
}

StreamReader reader = new StreamReader(inputPath);

string? line = reader.ReadLine();

PartLine lastLine = null;

int count = 0;
while (line != null)
{
    var currentLine = new PartLine(line, count);

    currentLine.Last = lastLine;
    if (lastLine != null) lastLine.Next = currentLine;

    lastLine = currentLine;

    count++;
    line = reader.ReadLine();
}

Console.WriteLine($"");
