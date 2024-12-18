using AdventOfCode2024.Helpers;
using AdventOfCode2024.Models;

namespace AdventOfCode2024.Tasks
{
    public class Task10
    {
        List<List<int>> list = new List<List<int>>();
        int width = 0;
        int height = 0;
        public Task10()
        {
            var lines = FileHelper.ReadLines("Input10.txt");

            foreach (var line in lines)
            {
                list.Add(line.Select(x => int.Parse(x.ToString())).ToList());
            }

            width = list[0].Count;
            height = list.Count;
        }

        public void Part1()
        {
            var result = 0;

            for(var i = 0; i < list.Count; i++)
                for(var j = 0; j < list[i].Count; j++)
                {
                    if (list[i][j] != 0)
                        continue;

                    var headCorrdinates = new List<Coordinate>();

                    FindHeads(i, j, headCorrdinates);

                    result += headCorrdinates.DistinctBy(x => new { x.X, x.Y }).Count();

                }


            OutputHelper.ShowResult(10, 1, result);
        }

        public void Part2()
        {
            var result = 0;

            for (var i = 0; i < list.Count; i++)
                for (var j = 0; j < list[i].Count; j++)
                {
                    if (list[i][j] != 0)
                        continue;

                    var headCorrdinates = new List<Coordinate>();

                    FindHeads(i, j, headCorrdinates);

                    result += headCorrdinates.Count();

                }

            OutputHelper.ShowResult(10, 2, result);
        }

        private void FindHeads(int x, int y, List<Coordinate> headCorrdinates)
        {
            var curValue = list[x][y];

            if (curValue == 9)
            {
                headCorrdinates.Add(new Coordinate { X = x, Y = y });
                return;
            }

            if(x + 1 < width && list[x + 1][y] == curValue + 1)
                FindHeads(x + 1, y, headCorrdinates);

            if (x - 1 >= 0 && list[x - 1][y] == curValue + 1)
                FindHeads(x - 1, y, headCorrdinates);

            if (y + 1 < height && list[x][y + 1] == curValue + 1)
                FindHeads(x, y + 1, headCorrdinates);

            if (y - 1 >= 0 && list[x][y - 1] == curValue + 1)
                FindHeads(x, y - 1, headCorrdinates);
        }
    }
}
