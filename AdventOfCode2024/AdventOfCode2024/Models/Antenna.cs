using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Models
{
    public class Antenna
    {
        public char Letter {  get; set; }
        public List<Coordinate> ItemsCoordinates { get; set; } = new List<Coordinate>();
    }
}
