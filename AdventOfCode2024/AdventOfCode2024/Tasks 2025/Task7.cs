using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task7
    {
        private List<string> lines;

        public Task7()
        {
            lines = FileHelper.ReadLines("2025_Input7.txt");
        }

        public void Part1()
        {
            long result = 0;

            lines[0] = lines[0].Replace('S', '|');

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != '|')
                        continue;

                    if (i < lines.Count - 1 && lines[i + 1][j] == '.')
                    {
                        lines[i + 1] = lines[i + 1].Substring(0, j) + "|" + lines[i + 1].Substring(j + 1);
                        continue;
                    }

                    if (i < lines.Count - 1 && lines[i + 1][j] == '^')
                    {
                        var splitPerformed = false;

                        if (j > 0 && lines[i + 1][j - 1] == '.')
                        {
                            lines[i + 1] = lines[i + 1].Substring(0, j - 1) + "|" + lines[i + 1].Substring(j);
                            splitPerformed = true;
                        }

                        if (j < lines[i].Length - 1 && lines[i + 1][j + 1] == '.')
                        {
                            lines[i + 1] = lines[i + 1].Substring(0, j + 1) + "|" + lines[i + 1].Substring(j + 2);
                            splitPerformed = true;
                        }

                        if (splitPerformed)
                            result++;
                    }
                }
            }

            OutputHelper.ShowResult(1, 1, result);
        }

        public void Part2()
        {
            long result = 0;
            var i = 0;
            var j = lines[0].IndexOf('|');


            DoNextStep(i + 1, j, ref result);
            /*while (lines[startI][startJ] != '^')
                startI++;

            DoNextStep(startI, startJ - 1, ref result);
            DoNextStep(startI, startJ +1, ref result);*/


            OutputHelper.ShowResult(1, 2, result);
        }

        private void DoNextStep(int i, int j, ref long result)
        {
            if( i == lines.Count - 1)
            {
                result++;
                return;
            }

            if(lines[i][j] == '^')
            {
                DoNextStep(i, j - 1, ref result);
                DoNextStep(i, j + 1, ref result);
            }
            else
            {
                DoNextStep(i + 1, j, ref result);
            }

            /*while (lines[i][j] != '^')
                i++;

            DoNextStep(i, j - 1, ref result);
            DoNextStep(i, j + 1, ref result);*/
        }
    }
}
