namespace AdventOfCode2024.Helpers
{
    public static class FileHelper
    {
        public static List<string> ReadLines(string inputFileName)
        {
            var filePath = $"C:\\AZ\\Projects\\Advent of Code 2024\\AdventOfCode2024\\Inputs\\{inputFileName}";
            var lines = File.ReadAllLines(filePath).ToList();
            return lines;
        }

        public static string ReadText(string inputFileName)
        {
            var filePath = $"C:\\AZ\\Projects\\Advent of Code 2024\\AdventOfCode2024\\Inputs\\{inputFileName}";
            var text = File.ReadAllText(filePath);
            return text;
        }
    }
}
