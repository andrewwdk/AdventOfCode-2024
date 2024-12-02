
using AdventOfCode2024.Tasks;

void Task2()
{
    var filePath = "C:\\AZ\\Projects\\Advent of Code 2024\\AdventOfCode2024\\Inputs\\Input2.txt";
    var lines = System.IO.File.ReadAllLines(filePath).ToList();

    var reportList = new List<List<int>>();

    foreach (var line in lines)
    {
        var items = line.Split(' ').Where(x => string.IsNullOrEmpty(x) == false);
        reportList.Add(items.Select(x => int.Parse(x)).ToList());
    }

    //Task2_Part1(reportList);
    Task2_Part2(reportList);

    /**/
}

void Task2_Part1(List<List<int>> reportList)
{
    var saveCount = 0;

    foreach (var report in reportList)
    {
        var increasingFlag = report[0] < report[1];
        var isSafe = false;

        for (int i = 0; i < report.Count - 1; i++)
        {
            var diff = Math.Abs(report[i] - report[i + 1]);

            if (diff < 1 || diff > 3)
            {
                isSafe = false;
                break;
            }

            if (increasingFlag)
            {
                if (report[i] < report[i + 1])
                {
                    isSafe = true;
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }
            else
            {
                if (report[i] > report[i + 1])
                {
                    isSafe = true;
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }
        }

        if (isSafe)
            saveCount++;
    }

    Console.WriteLine(saveCount);
}

void Task2_Part2(List<List<int>> reportList)
{
    var saveCount = 0;

    foreach (var report in reportList)
    {
        var isSafe = IsReportSafe(report);

        if (isSafe)
            saveCount++;
        else
        {   
            for(int i = 0;i < report.Count; i++)
            {
                var newReport = report.ToList();
                newReport.RemoveAt(i);

                if( IsReportSafe(newReport))
                {
                    saveCount++;
                    break;
                }
            }
        }
    }

    Console.WriteLine(saveCount);
}

bool IsReportSafe(List<int> report)
{
    var increasingFlag = report[0] < report[1];
    var isSafe = false;

    for (int i = 0; i < report.Count - 1; i++)
    {
        var diff = Math.Abs(report[i] - report[i + 1]);

        if (diff < 1 || diff > 3)
        {
            isSafe = false;
            break;
        }

        if (increasingFlag)
        {
            if (report[i] < report[i + 1])
            {
                isSafe = true;
            }
            else
            {
                isSafe = false;
                break;
            }
        }
        else
        {
            if (report[i] > report[i + 1])
            {
                isSafe = true;
            }
            else
            {
                isSafe = false;
                break;
            }
        }
    }

    return isSafe;
}

//Task1();
//Task2();

var task1 = new Task1();
task1.Part1();
task1.Part2();
