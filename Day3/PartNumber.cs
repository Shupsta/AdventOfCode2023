namespace Day3;

public class PartNumber
{
    public int Number { get; private set; }
    public int StartIndex { get; private set; }
    public int EndIndex { get; private set; }

    public PartNumber(int number, int start, int end)
    {
        Number = number;
        StartIndex = start;
        EndIndex = end;
    }
}