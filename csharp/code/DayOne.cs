namespace code;

public class DayOne
{
    public static async Task<int> SolveAsync(int startPosition, string inputFilePath)
    {
        var fileContent = await InputReader.ReadInputFileAsync(inputFilePath);
        var currentPosition = startPosition;
        var result = 0;

        foreach (var line in fileContent)
        {
            if (!int.TryParse(line[1..], out int num))
                continue;

            if (line[0].Equals('L'))
                num *= -1;

            currentPosition = GetNewPosition(currentPosition, num);

            if (currentPosition == 0)
                result++;
        }

        return result;
    }

    public static async Task<int> SolvePartTwoAsync(int startPosition, string inputFilePath)
    {
        var fileContent = await InputReader.ReadInputFileAsync(inputFilePath);
        var currentPosition = startPosition;
        var result = 0;

        foreach (var line in fileContent)
        {
            if (!int.TryParse(line[1..], out int num))
                continue;

            if (line[0].Equals('L'))
                num *= -1;

            result += GetNumberZeroPasses(currentPosition, num);

            currentPosition = GetNewPosition(currentPosition, num);

            if (currentPosition is < 0 or > 99)
                throw new ApplicationException($"CurrentPosition is wrong {currentPosition} for line {line}");

            if (currentPosition == 0)
                result += 1;
        }

        return result;
    }

    public static int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public static int GetNewPosition(int currentPosition, int num)
    {
        var result = Mod(currentPosition + num, 100);
        if (result is < 0 or > 99)
            throw new ApplicationException($"CurrentPosition is wrong for parameters {currentPosition},{num} result = {result}");
        return result;
    }

    public static int GetNumberZeroPasses(int currentPosition, int num)
    {
        if (num == 0)
            return 0;

        // for rotations that are bigger than 100
        var result = Math.Abs(num) / 100;

        // check if we've passed 0 with a small rotation
        if (result == 0 && currentPosition != 0 && (currentPosition + num) is < 0 or > 100)
            result += 1;

        return result;
    }
}