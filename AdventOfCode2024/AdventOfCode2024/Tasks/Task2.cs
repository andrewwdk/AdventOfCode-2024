using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks
{
    public class Task2
    {
        List<List<int>> _reportList = new List<List<int>>();

        public Task2()
        {
            var lines = FileHelper.ReadLines("Input2.txt");

            foreach (var line in lines)
                _reportList.Add(ParsingHelper.ConvertStringToIntList(line, " "));
        }

        public void Part1()
        {
            var saveCount = 0;

            foreach (var report in _reportList)
                if (IsReportSafe(report))
                    saveCount++;

            OutputHelper.ShowResult(2, 1, saveCount);
        }

        public void Part2()
        {
            var saveCount = 0;

            foreach (var report in _reportList)
            {
                if (IsReportSafe(report))
                {
                    saveCount++;
                    continue;
                }

                for (int i = 0; i < report.Count; i++)
                {
                    var newReport = report.ToList();
                    newReport.RemoveAt(i);

                    if (IsReportSafe(newReport))
                    {
                        saveCount++;
                        break;
                    }
                }
            }

            OutputHelper.ShowResult(2, 2, saveCount);
        }

        private bool IsReportSafe(List<int> report)
        {
            var increasingFlag = report[0] < report[1];

            for (int i = 0; i < report.Count - 1; i++)
            {
                var diff = Math.Abs(report[i] - report[i + 1]);

                if (diff < 1 || diff > 3)
                    return false;

                if ((increasingFlag && report[i] >= report[i + 1]) || (!increasingFlag && report[i] <= report[i + 1]))
                    return false;
            }

            return true;
        }
    }
}
