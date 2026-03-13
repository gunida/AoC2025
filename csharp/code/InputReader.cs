namespace code;

public static class InputReader
{
    public static async Task<string[]> ReadInputFileAsync(string filePath)
    {
        var fileContent = await File.ReadAllLinesAsync(filePath);

        return fileContent;
    }
}
