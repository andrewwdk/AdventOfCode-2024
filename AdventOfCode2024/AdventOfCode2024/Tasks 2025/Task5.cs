using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Tasks_2025
{
    public class Task5
    {
        private List<string> lines = new List<string>();
        private List<(long, long)> ranges = new List<(long, long)>();
        private List<long> ids = new List<long>();

        public Task5()
        {
            lines = FileHelper.ReadLines("2025_Input5.txt");

            foreach (string line in lines)
            {
                if (line.Contains('-'))
                {
                    var values = line.Split('-').Where(x => x != string.Empty).Select(long.Parse).ToList();
                    ranges.Add(new(values[0], values[1]));
                }
                else if (!string.IsNullOrEmpty(line))
                    ids.Add(long.Parse(line));
            }
        }

        public void Part1()
        {
            var count = 0;

            foreach (var id in ids)
            {
                foreach (var range in ranges)
                {
                    if (id >= range.Item1 && id <= range.Item2)
                    {
                        count++;
                        break;
                    }
                }
            }

            OutputHelper.ShowResult(1, 1, count);
        }

        public void Part2()
        {
            long count = 0;
            var newRanges = new List<(long, long)>();

            foreach (var range in ranges)
            {
                if (newRanges.Count == 0)
                {
                    newRanges.Add(range);
                    continue;
                }

                var insertedIndex = 0;

                for (var i = 0; i < newRanges.Count; i++)
                {
                    if (range.Item2 < newRanges[i].Item1)
                    {
                        newRanges.Insert(i, range);
                        insertedIndex = i;
                        break;
                    }

                    if (i == newRanges.Count - 1)
                    {
                        newRanges.Add(range);
                        insertedIndex = i + 1;
                        break;
                    }
                }

                var wasChangesMade = true;

                while (wasChangesMade)
                {
                    wasChangesMade = false;

                    if (insertedIndex < newRanges.Count - 1 && newRanges[insertedIndex].Item2 >= newRanges[insertedIndex + 1].Item1)
                    {
                        newRanges[insertedIndex] =
                            (
                                newRanges[insertedIndex].Item1 < newRanges[insertedIndex].Item1 ? newRanges[insertedIndex].Item1 : newRanges[insertedIndex].Item1,
                                newRanges[insertedIndex + 1].Item2 > newRanges[insertedIndex].Item2 ? newRanges[insertedIndex + 1].Item2 : newRanges[insertedIndex].Item2
                            );
                        newRanges.RemoveAt(insertedIndex + 1);
                        wasChangesMade = true;
                    }

                    if (insertedIndex != 0 && newRanges[insertedIndex].Item1 <= newRanges[insertedIndex - 1].Item2)
                    {
                        newRanges[insertedIndex - 1] =
                            (
                                newRanges[insertedIndex - 1].Item1 < newRanges[insertedIndex].Item1 ? newRanges[insertedIndex - 1].Item1 : newRanges[insertedIndex].Item1,
                                newRanges[insertedIndex].Item2 > newRanges[insertedIndex - 1].Item2 ? newRanges[insertedIndex].Item2 : newRanges[insertedIndex - 1].Item2
                            );
                        newRanges.RemoveAt(insertedIndex);
                        wasChangesMade = true;
                    }

                    insertedIndex--;
                }
            }

            foreach (var range in newRanges)
                count = count + range.Item2 - range.Item1 + 1;

            OutputHelper.ShowResult(1, 2, count);
        }
    }
}
