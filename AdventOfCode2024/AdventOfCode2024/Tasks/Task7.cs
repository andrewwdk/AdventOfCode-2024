using AdventOfCode2024.Helpers;
using AdventOfCode2024.Models;

namespace AdventOfCode2024.Tasks
{
    public class Task7
    {
        private List<Operation> _operations = new List<Operation>();
        public Task7()
        {
            var lines = FileHelper.ReadLines("Input7.txt");

            foreach (var line in lines)
                _operations.Add(new Operation(line));
        }

        public void Part1()
        {
            long sum = 0;

            foreach (var operation in _operations)
                if (operation.IsBinarySolvable())
                    sum += operation.Sum;

            OutputHelper.ShowResult(7, 1, sum);
        }

        public void Part2()
        {
            long sum = 0;

            foreach (var operation in _operations)
                if (operation.IsTrinarySolvable())
                    sum += operation.Sum;

            OutputHelper.ShowResult(7, 2, sum);
        }
    }
}
