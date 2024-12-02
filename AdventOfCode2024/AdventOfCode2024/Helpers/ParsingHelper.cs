using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class ParsingHelper
    {
        public static List<int> ConvertStringToIntList(string line, string separator)
        {
            var items = line.Split(' ').Where(x => string.IsNullOrEmpty(x) == false);
            return items.Select(int.Parse).ToList();
        }
    }
}
