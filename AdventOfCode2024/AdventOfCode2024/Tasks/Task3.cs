using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Tasks
{
    public class Task3
    {
        private string _text;
        public Task3() 
        {
            _text = FileHelper.ReadText("Input3.txt");
        }

        public void Part1()
        {
            var result = 0;

            Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
            MatchCollection matches = regex.Matches(_text);
            if (matches.Count > 0)
            {
                foreach (var m in matches) 
                    result += Multiply(m.ToString());
            }

            OutputHelper.ShowResult(3, 1, result);
        }

        public void Part2()
        {
            var result = 0;
            Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)");
            MatchCollection matches = regex.Matches(_text);
            bool enabled = true;

            if (matches.Count > 0)
            {
                foreach (var m in matches)
                {
                    var instruction = m.ToString();

                    if ( instruction == "do()")
                    {
                        enabled = true;
                        continue;
                    }

                    if (instruction == "don't()")
                    {
                        enabled = false;
                        continue;
                    }

                    if(enabled)
                        result += Multiply(instruction);
                }
            }


            OutputHelper.ShowResult(3, 2, result);
        }

        private int Multiply(string str)
        {
            var startIndex = str.IndexOf('(');
            var middleIndex = str.IndexOf(',');
            var endIndex = str.IndexOf(')');
            int number1 = int.Parse(str.Substring(startIndex + 1, middleIndex - startIndex - 1));
            int number2 = int.Parse(str.Substring(middleIndex + 1, endIndex - middleIndex - 1));
            return number1*number2;
        }
    }
}
