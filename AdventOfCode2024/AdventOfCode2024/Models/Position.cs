using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2024.Enums;

namespace AdventOfCode2024.Models
{
    public class Position
    {
        public bool IsVisited {  get; set; }
        public bool IsObsticle { get; set; }
        public bool IsStarting { get; set; }
        public List<Direction> UsedDirections { get; set; } = new List<Direction>();
    }
}
