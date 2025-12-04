using AdventOfCode2024.Helpers;
using System.Text;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task4
    {
        private List<string> lines = new List<string>();
        private int lineLength;
        private int lineCount;

        public Task4()
        {
            lines = FileHelper.ReadLines("2025_Input4.txt");
            lineLength = lines[0].Length;
            lineCount = lines.Count;
        }

        public void Part1()
        {
            var count = 0;

            for (int i = 0; i < lineCount; i++)
                for (int j = 0; j < lineLength; j++)
                {
                    if (lines[i][j] != '@')
                        continue;

                    if (GetNeighbourCount(i, j) < 4)
                        count++;
                }

            OutputHelper.ShowResult(1, 1, count);
        }

        private int GetNeighbourCount(int i, int j)
        {
            var count = 0;

            if (i > 0 && j > 0 && lines[i - 1][j - 1] == '@')
                count++;

            if (i > 0 && lines[i - 1][j] == '@')
                count++;

            if (i > 0 && j < lineLength - 1 && lines[i - 1][j + 1] == '@')
                count++;

            if (i < lineCount - 1 && j < lineLength - 1 && lines[i + 1][j + 1] == '@')
                count++;

            if (i < lineCount - 1 && lines[i + 1][j] == '@')
                count++;

            if (i < lineCount - 1 && j > 0 && lines[i + 1][j - 1] == '@')
                count++;

            if (j > 0 && lines[i][j - 1] == '@')
                count++;

            if (j < lineLength - 1 && lines[i][j + 1] == '@')
                count++;

            return count;
        }

        public void Part2()
        {
            var totalCount = 0;
            var removalList = new List<(int, int)> { (0, 0) };

            while (removalList.Count != 0)
            {
                removalList.Clear();

                for (int i = 0; i < lineCount; i++)
                    for (int j = 0; j < lineLength; j++)
                    {
                        if (lines[i][j] != '@')
                            continue;

                        if (GetNeighbourCount(i, j) < 4)
                            removalList.Add((i, j));
                    }

                removalList.ForEach(x =>
                {
                    var temp = new StringBuilder(lines[x.Item1]);
                    temp[x.Item2] = '.';
                    lines[x.Item1] = temp.ToString();
                });
                totalCount += removalList.Count;
            }

            OutputHelper.ShowResult(1, 2, totalCount);
        }
    }
}
