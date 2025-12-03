using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task3
    {
        private List<List<int>> banks = new List<List<int>>();

        public Task3()
        {
            var lines = FileHelper.ReadLines("2025_Input3.txt");

            foreach (var line in lines)
            {
                banks.Add(line.Select(x => int.Parse(x.ToString())).ToList());
            }
        }

        public void Part1()
        {
            int sum = 0;

            foreach (var bank in banks)
            {
                var maxDigit = bank.Max();
                var maxDigitIndex = bank.IndexOf(maxDigit);

                if (maxDigitIndex == bank.Count() - 1)
                {
                    maxDigit = bank.Take(bank.Count() - 1).Max();
                    maxDigitIndex = bank.IndexOf(maxDigit);
                }

                var secondMaxDigit = bank.Skip(maxDigitIndex + 1).Max();
                sum += (secondMaxDigit + maxDigit * 10);
            }

            OutputHelper.ShowResult(1, 1, sum);
        }

        public void Part2()
        {
            long sum = 0;

            foreach (var bank in banks)
            {
                string joltage = string.Empty;
                int maxDigitIndex = -1;

                for (int i = 12; i > 0; i--)
                {
                    var nextMaxDigit = GetNextMax(bank, i, ref maxDigitIndex);
                    joltage += nextMaxDigit.ToString();
                }

                sum += long.Parse(joltage);
            }

            OutputHelper.ShowResult(1, 2, sum);
        }

        private int GetNextMax(List<int> bank, int margin, ref int index)
        {
            var truncatedBank = bank.Skip(index + 1).SkipLast(margin - 1).ToList();
            var maxDigit = truncatedBank.Max();
            index = index + 1 + truncatedBank.IndexOf(maxDigit);
            return maxDigit;
        }
    }
}
