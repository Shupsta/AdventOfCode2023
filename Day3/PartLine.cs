using System;

namespace Day3;

public class PartLine
{
    public PartLine Last { get; set; } = null;
    public PartLine Next { get; set; } = null;
    public int? LineNumber { get; } = null;
    public List<PartNumber> Numbers = new List<PartNumber>();

    public PartLine(string inputLine, int lineNum)
    {
        LineNumber = lineNum;
        for (int i = 0; i < inputLine.Length; i++)
        {
            char current = inputLine[i];
            if (Char.IsDigit(current))
            {
                int j = i+1;
                char next = inputLine[j];
                while (Char.IsDigit(next))
                {
                    j++;
                    if (j >= inputLine.Length) break;
                    next = inputLine[j];
                }

                string numberString = inputLine.Substring(i, j-i);
                j = j - 1;
                if (int.TryParse(numberString, out int number)) Numbers.Add(new PartNumber(number, i, j));
                i = j;

            }
        }
    }
}