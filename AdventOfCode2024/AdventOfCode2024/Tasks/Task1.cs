using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks
{
    public class Task1
    {
        private List<int> firstList = new List<int>();
        private List<int> secondList = new List<int>();
        public Task1()
        {
            var lines = FileHelper.ReadLines("Input1.txt");

            foreach (var line in lines)
            {
                var items = line.Split("   ");
                firstList.Add(int.Parse(items[0]));
                secondList.Add(int.Parse(items[1]));
            }

            firstList.Sort();
            secondList.Sort();
        }

        public void Part1()
        {
            var distance = 0;

            for (int i = 0; i < firstList.Count; i++)
            {
                distance += Math.Abs(firstList[i] - secondList[i]);
            }

            OutputHelper.ShowResult(1, 1, distance);
        }

        public void Part2()
        {
            var similarity = 0;

            for (int i = 0; i < firstList.Count; i++)
            {
                var id = firstList[i];
                var appearence = secondList.Count(x => x == id);
                similarity += id * appearence;
            }

            OutputHelper.ShowResult(1, 2, similarity);
        }
    }
}
