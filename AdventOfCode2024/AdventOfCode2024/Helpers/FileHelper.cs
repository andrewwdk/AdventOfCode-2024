using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
