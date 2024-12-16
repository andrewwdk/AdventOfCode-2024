using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class OutputHelper
    {
        public static void ShowResult(int task, int part, int result) =>
            Console.WriteLine($"Task {task} Part {part} Result {result}");

        public static void ShowResult(int task, int part, long result) =>
            Console.WriteLine($"Task {task} Part {part} Result {result}");
    }
}
