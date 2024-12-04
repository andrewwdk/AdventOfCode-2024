using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Tasks
{
    public class Task4
    {
        private List<string> _lines;
        public Task4()
        {
            _lines = FileHelper.ReadLines("Input4.txt");
        }

        public void Part1()
        {
            var count = 0;
            var linesCount = _lines.Count;
            var linesLength = _lines[0].Length;

            for (int i = 0; i < linesCount; i++) 
            {
                for (int j = 0; j < linesLength; j++)
                {
                    if (_lines[i][j] != 'X')
                        continue;

                    if (j < linesLength - 3 && _lines[i][j + 1] == 'M' && _lines[i][j + 2] == 'A' && _lines[i][j + 3] == 'S')
                        count++;

                    if (j > 2 && _lines[i][j - 1] == 'M' && _lines[i][j - 2] == 'A' && _lines[i][j - 3] == 'S')
                        count++;

                    if (i < linesCount - 3 && _lines[i + 1][j] == 'M' && _lines[i + 2][j] == 'A' && _lines[i + 3][j] == 'S')
                        count++;

                    if (i > 2 && _lines[i - 1][j] == 'M' && _lines[i - 2][j] == 'A' && _lines[i - 3][j] == 'S')
                        count++;

                    if (j < linesLength - 3 && i < linesCount - 3 && _lines[i + 1][j + 1] == 'M' && _lines[i + 2][j + 2] == 'A' && _lines[i + 3][j + 3] == 'S')
                        count++;

                    if (j > 2 && i > 2 && _lines[i - 1][j - 1] == 'M' && _lines[i - 2][j - 2] == 'A' && _lines[i - 3][j - 3] == 'S')
                        count++;

                    if (j < linesLength - 3 && i > 2 && _lines[i - 1][j + 1] == 'M' && _lines[i - 2][j + 2] == 'A' && _lines[i - 3][j + 3] == 'S')
                        count++;

                    if (j > 2 && i < linesCount - 3 && _lines[i + 1][j - 1] == 'M' && _lines[i + 2][j - 2] == 'A' && _lines[i + 3][j - 3] == 'S')
                        count++;

                }
            }

            OutputHelper.ShowResult(4, 1, count);
        }

        public void Part2() 
        {
            var count = 0;
            var linesCount = _lines.Count;
            var linesLength = _lines[0].Length;

            for (int i = 1; i < linesCount-1; i++)
            {
                for (int j = 1; j < linesLength-1; j++)
                {
                    if (_lines[i][j] != 'A')
                        continue;

                    if (_lines[i - 1][j - 1] == 'M' && _lines[i - 1][j + 1] == 'S' && _lines[i + 1][j + 1] == 'S' && _lines[i + 1][j - 1] == 'M')
                        count++;

                    if (_lines[i - 1][j - 1] == 'M' && _lines[i - 1][j + 1] == 'M' && _lines[i + 1][j + 1] == 'S' && _lines[i + 1][j - 1] == 'S')
                        count++;

                    if (_lines[i - 1][j - 1] == 'S' && _lines[i - 1][j + 1] == 'S' && _lines[i + 1][j + 1] == 'M' && _lines[i + 1][j - 1] == 'M')
                        count++;

                    if (_lines[i - 1][j - 1] == 'S' && _lines[i - 1][j + 1] == 'M' && _lines[i + 1][j + 1] == 'M' && _lines[i + 1][j - 1] == 'S')
                        count++;

                }
            }

            OutputHelper.ShowResult(4, 1, count);
        }
    }
}
