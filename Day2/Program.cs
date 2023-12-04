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

int[] RGBMax = new[] { 12, 13, 14 };
string[] RGBWords = new[] { "red", "green", "blue" };

int powerCount = 0;
int count = 0;
while (line != null)
{
    bool doCount = true;
    string[] idAndData = line.Split(": ");
    if(idAndData.Length < 2) continue;
    string idString = idAndData[0];
    string data = idAndData[1];
    string[] games = data.Split("; ");
    if(games.Length < 1) continue;

    int[] RGBPrev = new[] { 0, 0, 0 };


    foreach (var game in games)
    {
        string[] colorAndNums = game.Split(", ");
        if(colorAndNums.Length < 1) continue;
        foreach (string colorAndNum in colorAndNums)
        {
            string[] parts = colorAndNum.Split(' ');
            if(parts.Length < 2) continue;
            string numString = parts[0];
            string color = parts[1];

            if (int.TryParse(numString, out int number))
            {
                for (int i = 0; i < RGBWords.Length; i++)
                {
                    string rgbWord = RGBWords[i];
                    if (color.Contains(rgbWord))
                    {
                        if (RGBPrev[i] < number) RGBPrev[i] = number;
                    }
                }
            }
        }
    }

    int gamePower = 1;
    for (int i = 0; i < RGBPrev.Length; i++)
    {
        if (RGBPrev[i] > RGBMax[i]) doCount = false;
        gamePower *= RGBPrev[i];
    }

    powerCount += gamePower;

    string[] idParts = idString.Split(' ');
    if (doCount && int.TryParse(idParts[1], out int idNumber)) count += idNumber;

    line = reader.ReadLine();
}

Console.WriteLine($"{count}");
