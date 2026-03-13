using code;

namespace tests;

public class InputReaderTests
{
    [Fact]
    public async Task InputReader_ShouldReadFromFile()
    {
        var content = await InputReader.ReadInputFileAsync("sample.txt");

        Assert.Equal("hello world!", content[0]);
    }
}
