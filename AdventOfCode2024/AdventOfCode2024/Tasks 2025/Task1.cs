using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task1
    {
        private List<int> firstList = new List<int>();
        private List<int> secondList = new List<int>();

        public Task1()
        {
            var lines = FileHelper.ReadLines("2025_Input1.txt");

            foreach (var line in lines)
            {
                var items = line.Split("   ");
                firstList.Add(line[0] == 'L' ? -1 : 1); // -1 for left, 1 for right
                secondList.Add(int.Parse(line.Substring(1)));
            }
        }

        public void Part1()
        {
            var currentState = 50;
            var zeroCount = 0;

            for (int i = 0; i < firstList.Count; i++)
            {
                var clickNumber = secondList[i] % 100; ;

                if (firstList[i] == -1)
                {
                    currentState -= clickNumber;

                    if (currentState < 0)
                        currentState += 100;
                }
                else
                {
                    currentState += clickNumber;

                    if (currentState > 99)
                        currentState -= 100;
                }

                if (currentState == 0)
                    zeroCount++;
            }

            OutputHelper.ShowResult(1, 1, zeroCount);
        }

        public void Part2()
        {
            var currentState = 50;
            var zeroCount = 0;

            for (int i = 0; i < firstList.Count; i++)
            {
                var clickNumber = secondList[i] % 100;
                var fullCircleNumber = secondList[i] / 100;
                zeroCount += fullCircleNumber;

                if (clickNumber == 0)
                    continue;

                if (firstList[i] == -1)
                {
                    var previousWasZero = currentState == 0;
                    currentState -= clickNumber;

                    if (currentState < 0)
                    {
                        currentState += 100;
                        if(!previousWasZero)
                            zeroCount++;
                    }

                    if (currentState == 0)
                    {
                        zeroCount++;
                    }
                }
                else
                {
                    currentState += clickNumber;

                    if (currentState > 99)
                    {
                        currentState -= 100;
                        zeroCount++;
                    }
                }
            }

            OutputHelper.ShowResult(1, 2, zeroCount);
        }
    }
}
