using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task6
    {
        private List<long> list1 = new List<long>();
        private List<long> list2 = new List<long>();
        private List<long> list3 = new List<long>();
        private List<long> list4 = new List<long>();
        private List<string> math = new List<string>();
        private List<string> lines;

        public Task6()
        {
            lines = FileHelper.ReadLines("2025_Input6.txt");

            list1 = lines[0].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
            list2 = lines[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
            list3 = lines[2].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
            list4 = lines[3].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
            math = lines[4].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
            //math = lines[3].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public void Part1()
        {
            long result = 0;

            for(int i=0; i < list1.Count; i++)
            {
                if (math[i] == "+")
                    result += list1[i] + list2[i] + list3[i] + list4[i];
                else
                    result += (list1[i] * list2[i] * list3[i] * list4[i]);
            }

            OutputHelper.ShowResult(1, 1, result);
        }

        public void Part2()
        {
            long result = 0;
            var previousIndex = 0;
            var mathIndex = 0;

            for (int index = 0; index < lines[0].Length; index++)
            {
                if ((lines[0][index] == ' ' && lines[1][index] == ' ' && lines[2][index] == ' ' && lines[3][index] == ' ') || index == lines[0].Length - 1)
                {
                    if (index == lines[0].Length - 1)
                        index++;

                    var number1 = lines[0].Substring(previousIndex, index - previousIndex);
                    var number2 = lines[1].Substring(previousIndex, index - previousIndex);
                    var number3 = lines[2].Substring(previousIndex, index - previousIndex);
                    var number4 = lines[3].Substring(previousIndex, index - previousIndex);
                    previousIndex = index + 1;


                    var newNumbers = GetNewNumbers(new List<string> { number1, number2, number3, number4 });
                    long currentResult;
                    if (math[mathIndex] == "+")
                        currentResult = newNumbers.Sum();
                    else
                        currentResult = newNumbers.Aggregate(1, (long acc, long x) => acc * x);

                    result += currentResult;
                    mathIndex++;
                }
            }

            OutputHelper.ShowResult(1, 2, result);
        }

        private List<long> GetNewNumbers(List<string> numbers)
        {
            var newList = new List<long>();

            for(int i = numbers[0].Length - 1; i >= 0; i--)
            {
                var sb = new StringBuilder();
                numbers.ForEach(x =>
                {
                    if (x[i] != ' ')
                        sb.Append(x[i]);
                });
                newList.Add(long.Parse(sb.ToString()));
            }

            return newList;
        }
    }
}
