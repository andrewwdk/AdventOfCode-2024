using AdventOfCode2024.Helpers;
using AdventOfCode2024.Models;

namespace AdventOfCode2024.Tasks
{
    public class Task8
    {
        private int _width;
        private int _height;
        private List<Antenna> _antennaList = new List<Antenna>();
        private List<Coordinate> _antiNode = new List<Coordinate>();
        private List<Coordinate> _antiNodesPart2 = new List<Coordinate>();

        public Task8()
        {
            var lines = FileHelper.ReadLines("Input8.txt");

            _width = lines[0].Length;
            _height = lines.Count;

            for (int i = 0; i < lines.Count; i++)
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != '.')
                    {
                        var ch = lines[i][j];
                        var antenna = _antennaList.FirstOrDefault(x => x.Letter == ch);

                        if (antenna == null)
                        {
                            antenna = new Antenna() { Letter = ch };
                            _antennaList.Add(antenna);
                        }

                        antenna.ItemsCoordinates.Add(new Coordinate { X = j, Y = i });
                    }
                }
        }

        public void Part1()
        {
            foreach (var antenna in _antennaList)
            {
                var coords = antenna.ItemsCoordinates;

                for (var i = 0; i < coords.Count - 1; i++)
                    for (var j = i + 1; j < coords.Count; j++)
                    {
                        var xDiff = Math.Abs(coords[i].X - coords[j].X);
                        var yDiff = Math.Abs(coords[i].Y - coords[j].Y);

                        // antinode for i point 
                        var x1 = coords[i].X < coords[j].X ? coords[i].X - xDiff : coords[i].X + xDiff;
                        var y1 = coords[i].Y < coords[j].Y ? coords[i].Y - yDiff : coords[i].Y + yDiff;

                        // y
                        var x2 = coords[j].X < coords[i].X ? coords[j].X - xDiff : coords[j].X + xDiff;
                        var y2 = coords[j].Y < coords[i].Y ? coords[j].Y - yDiff : coords[j].Y + yDiff;

                        if (x1 >= 0 && x1 < _width && y1 >= 0 && y1 < _height)
                            _antiNode.Add(new Coordinate { X = x1, Y = y1 });

                        if (x2 >= 0 && x2 < _width && y2 >= 0 && y2 < _height)
                            _antiNode.Add(new Coordinate { X = x2, Y = y2 });
                    }
            }

            var count = _antiNode.DistinctBy(x => new { x.X, x.Y }).Count();

            OutputHelper.ShowResult(8, 1, count);
        }

        public void Part2()
        {
            foreach (var antenna in _antennaList)
            {
                var coords = antenna.ItemsCoordinates;

                for (var i = 0; i < coords.Count - 1; i++)
                    for (var j = i + 1; j < coords.Count; j++)
                    {
                        _antiNodesPart2.Add(new Coordinate { X = coords[i].X, Y = coords[i].Y });
                        _antiNodesPart2.Add(new Coordinate { X = coords[j].X, Y = coords[j].Y });

                        var xDiff = Math.Abs(coords[i].X - coords[j].X);
                        var yDiff = Math.Abs(coords[i].Y - coords[j].Y);

                        int x1 = 0;
                        int y1 = 0;
                        int prevX1 = coords[i].X;
                        int prevY1 = coords[i].Y;

                        while (x1 >= 0 && x1 < _width && y1 >= 0 && y1 < _height)
                        {
                            x1 = coords[i].X < coords[j].X ? prevX1 - xDiff : prevX1 + xDiff;
                            y1 = coords[i].Y < coords[j].Y ? prevY1 - yDiff : prevY1 + yDiff;

                            if (x1 >= 0 && x1 < _width && y1 >= 0 && y1 < _height)
                                _antiNodesPart2.Add(new Coordinate { X = x1, Y = y1 });

                            prevX1 = x1;
                            prevY1 = y1;

                        }

                        int x2 = 0;
                        int y2 = 0;
                        int prevX2 = coords[j].X;
                        int prevY2 = coords[j].Y;

                        while (x2 >= 0 && x2 < _width && y2 >= 0 && y2 < _height)
                        {
                            x2 = coords[j].X < coords[i].X ? prevX2 - xDiff : prevX2 + xDiff;
                            y2 = coords[j].Y < coords[i].Y ? prevY2 - yDiff : prevY2 + yDiff;

                            if (x2 >= 0 && x2 < _width && y2 >= 0 && y2 < _height)
                                _antiNodesPart2.Add(new Coordinate { X = x2, Y = y2 });

                            prevX2 = x2;
                            prevY2 = y2;

                        }
                    }
            }

            long count = _antiNodesPart2.DistinctBy(x => new { x.X, x.Y }).Count(); ;

            OutputHelper.ShowResult(8, 2, count);
        }
    }
}
