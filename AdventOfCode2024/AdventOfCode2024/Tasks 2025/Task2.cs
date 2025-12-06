using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task2
    {
        private List<long> firstList = new List<long>();

        public Task2()
        {
            var lines = FileHelper.ReadLines("2025_Input2.txt");

            foreach (var line in lines)
            {
                firstList.AddRange(line.Split(',', '-').Where(x => x != string.Empty).Select(long.Parse));
            }
        }

        public void Part1()
        {
            long sum = 0;

            for (var i = 0; i < firstList.Count; i += 2)
            {
                for (var j = firstList[i]; j <= firstList[i + 1]; j++)
                {
                    var stringNumber = j.ToString();

                    if (stringNumber.Length % 2 == 1)
                        continue;

                    var part1 = stringNumber.Substring(0, stringNumber.Length / 2);
                    var part2 = stringNumber.Substring(stringNumber.Length / 2);

                    if (part1 == part2)
                        sum += j;
                }
            }

            OutputHelper.ShowResult(1, 1, sum);
        }

        public void Part2()
        {
            long sum = 0;

            for (var i = 0; i < firstList.Count; i += 2)
            {
                for (var j = firstList[i]; j <= firstList[i + 1]; j++)
                {
                    var stringNumber = j.ToString();

                    if (CheckNumber(stringNumber))
                        sum += j;
                }
            }

            OutputHelper.ShowResult(1, 2, sum);
        }

        private bool CheckNumber(string number)
        {
            var divisors = Enumerable.Range(2, number.Length).Where(x => number.Length % x == 0);

            foreach (var divisor in divisors)
            {
                var parts = SplitString(number, divisor);
                if (parts.Distinct().Count() == 1)
                    return true;
            }

            return false;
        }

        private List<string> SplitString(string str, int parts)
        {
            List<string> chunks = new List<string>();
            int chunkSize = (int)Math.Ceiling((double)str.Length / parts);

            for (int i = 0; i < str.Length; i += chunkSize)
            {
                chunks.Add(str.Substring(i, Math.Min(chunkSize, str.Length - i)));
            }

            return chunks;
        }
    }
}
