using AdventOfCode2024.Enums;
using AdventOfCode2024.Helpers;
using AdventOfCode2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Tasks
{
    public class Task6
    {
        private List<string> _lines;
        private List<List<Position>> _positions;
        private int startingI = 0;
        private int startingJ = 0;
        public Task6()
        {
            _lines = FileHelper.ReadLines("Input6.txt");
        }

        private void Init()
        {
            _positions = new List<List<Position>>();

            for (int i = 0; i < _lines.Count; i++)
            {
                var line = new List<Position>();
                for (int j = 0; j < _lines[i].Length; j++)
                {
                    var position = new Position();
                    var ch = _lines[i][j];

                    if (ch == '#')
                        position.IsObsticle = true;
                    else if (ch == '^')
                    {
                        position.IsStarting = true;
                        startingI = i;
                        startingJ = j;
                    }

                    line.Add(position);
                }
                _positions.Add(line);
            }
        }

        public void Part1()
        {
            Init();
            var count = 0;
            var curI = startingI;
            var curJ = startingJ;
            var curDirection = Direction.Top;

            while (!(_positions[curI][curJ].IsVisited && _positions[curI][curJ].UsedDirections.Contains(curDirection)))
            {
                _positions[curI][curJ].IsVisited = true;
                _positions[curI][curJ].UsedDirections.Add(curDirection);

                if (curI == 0 || curJ == 0 || curI == _positions.Count - 1 || curJ == _positions[curI].Count - 1)
                    break;

                if (curDirection == Direction.Top) 
                {
                    if (_positions[curI - 1][curJ].IsObsticle)
                        curDirection = Direction.Right;
                    else
                        curI--;

                    continue;
                }

                if (curDirection == Direction.Bottom)
                {
                    if (_positions[curI + 1][curJ].IsObsticle)
                        curDirection = Direction.Left;
                    else
                        curI++;

                    continue;
                }

                if (curDirection == Direction.Right)
                {
                    if (_positions[curI][curJ + 1].IsObsticle)
                        curDirection = Direction.Bottom;
                    else
                        curJ++;

                    continue;
                }

                if (curDirection == Direction.Left)
                {
                    if (_positions[curI][curJ - 1].IsObsticle)
                        curDirection = Direction.Top;
                    else
                        curJ--;

                    continue;
                }
            }

            for (int i = 0; i < _positions.Count; i++)  
            {
                for (int j = 0; j < _positions[0].Count; j++)
                {
                    //Console.Write(_positions[i][j].IsVisited ? "X" : ".");
                    if (_positions[i][j].IsVisited)
                        count++;
                }
               // Console.Write("\n");
            }

            OutputHelper.ShowResult(6, 1, count);
        }

        public void Part2()
        {
            var count = 0;

            for (int i = 0; i < _positions.Count; i++)
                for (int j = 0; j < _positions[0].Count; j++)
                {
                    Init();

                    if (_positions[i][j].IsObsticle || _positions[i][j].IsStarting)
                        continue;
                    else
                        _positions[i][j].IsObsticle = true;

                    var curI = startingI;
                    var curJ = startingJ;
                    var curDirection = Direction.Top;

                    while (true)
                    {
                        if(_positions[curI][curJ].IsVisited && _positions[curI][curJ].UsedDirections.Contains(curDirection))
                        {
                            count++;
                            break;
                        }

                        _positions[curI][curJ].IsVisited = true;
                        _positions[curI][curJ].UsedDirections.Add(curDirection);

                        if (curI == 0 || curJ == 0 || curI == _positions.Count - 1 || curJ == _positions[curI].Count - 1)
                            break;

                        if (curDirection == Direction.Top)
                        {
                            if (_positions[curI - 1][curJ].IsObsticle)
                                curDirection = Direction.Right;
                            else
                                curI--;

                            continue;
                        }

                        if (curDirection == Direction.Bottom)
                        {
                            if (_positions[curI + 1][curJ].IsObsticle)
                                curDirection = Direction.Left;
                            else
                                curI++;

                            continue;
                        }

                        if (curDirection == Direction.Right)
                        {
                            if (_positions[curI][curJ + 1].IsObsticle)
                                curDirection = Direction.Bottom;
                            else
                                curJ++;

                            continue;
                        }

                        if (curDirection == Direction.Left)
                        {
                            if (_positions[curI][curJ - 1].IsObsticle)
                                curDirection = Direction.Top;
                            else
                                curJ--;

                            continue;
                        }
                    }

                    _positions[i][j].IsObsticle = false;
                }


            //for (int i = 0; i < _positions.Count; i++)
            //{
            //    for (int j = 0; j < _positions[0].Count; j++)
            //    {
            //        //Console.Write(_positions[i][j].IsVisited ? "X" : ".");
            //        if (_positions[i][j].IsVisited)
            //            count++;
            //    }
            //    // Console.Write("\n");
            //}

            OutputHelper.ShowResult(6, 2, count);
        }
    }
}
