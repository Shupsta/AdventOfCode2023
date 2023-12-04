using System.Globalization;
using System.Text;

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

string[] numberWords = new[]
{
    "zero",
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine"
};

int count = 0;
while (line != null)
{
    char? firstChar = null;
    char? lastChar = null;
    int wordArrayIndex = 0;
    char[] wordArray = new char[line.Length];
    string word = string.Empty;

    foreach (char c in line)
    {
        if (Char.IsDigit(c))
        {
            if (firstChar == null) firstChar = c;
            lastChar = c;
        }
        else
        {
            wordArray.SetValue(c, wordArrayIndex);
            wordArrayIndex++;
            word = new string(wordArray);
            for (int i = 0; i < numberWords.Length; i++)
            {
                string numWord = numberWords[i];
                if (word.Contains(numWord))
                {
                    char indexNum = (char)('0' + i);

                    if (firstChar == null) firstChar = indexNum;
                    lastChar = indexNum;

                    int firstOcc = word.IndexOf(numWord);

                    wordArray[firstOcc] = Char.MinValue;
                }
            }
        }
    }

    string numberString = $"{firstChar}{lastChar}";

    if (int.TryParse(numberString, out int num)) count += num;

    line = reader.ReadLine();
}

Console.WriteLine($"{count}");
