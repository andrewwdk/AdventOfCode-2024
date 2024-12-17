using AdventOfCode2024.Helpers;
using AdventOfCode2024.Models;

namespace AdventOfCode2024.Tasks
{
    public class Task9
    {
        private List<MemoryUnit> _memory = new List<MemoryUnit>();
        private List<MemoryItem> _memoryItems = new List<MemoryItem>();

        public Task9()
        {
            var text = FileHelper.ReadText("Input9.txt");

            var curIndex = 0;
            var isFile = true;

            foreach (var ch in text)
            {
                var value = int.Parse(ch.ToString());

                for (var i = 0; i < value; i++)
                    _memory.Add(new MemoryUnit { Id = isFile ? curIndex : -1 });

                _memoryItems.Add(new MemoryItem { Id = isFile ? curIndex : -1, Size = value });

                if (isFile)
                    curIndex++;

                isFile = !isFile;
            }
        }

        public void Part1()
        {
            var memoryCopy = _memory.ToList();
            var fileItemCount = memoryCopy.Count(x => !x.IsEmpty);

            for (var i = 0; i < fileItemCount; i++)
            {
                if (!memoryCopy[i].IsEmpty)
                    continue;

                var lastFileIndex = memoryCopy.FindLastIndex(x => !x.IsEmpty);
                memoryCopy[i].Id = memoryCopy[lastFileIndex].Id;
                memoryCopy[lastFileIndex].Id = -1;
            }

            //long result = memoryCopy.Where(x => !x.IsEmpty).Select((x, i) => new { Value = x, Index = i }).Sum(x => x.Index * x.Value.Id);
            var usedMemory = memoryCopy.Where(x => !x.IsEmpty).ToList();
            long result = 0;

            for (var i = 0; i < usedMemory.Count; i++)
                result += usedMemory[i].Id * i;

            OutputHelper.ShowResult(9, 1, result);
        }

        public void Part2()
        {
            for (var i = _memoryItems.Count - 1; i > 0; i--)
            {
                if (_memoryItems[i].IsEmpty)
                    continue;

                var sizeToFind = _memoryItems[i].Size;

                for (var j = 0; j < i; j++)
                {
                    if (_memoryItems[j].IsEmpty && _memoryItems[j].Size >= sizeToFind)
                    {
                        if (_memoryItems[j].Size == sizeToFind)
                        {
                            _memoryItems[j].Id = _memoryItems[i].Id;
                            _memoryItems[i].Id = -1;
                        }
                        else
                        {
                            var newItem = new MemoryItem { Id = _memoryItems[i].Id, Size = sizeToFind };
                            _memoryItems[j].Size -= sizeToFind;
                            _memoryItems[i].Id = -1;
                            _memoryItems.Insert(j, newItem);
                            i++;
                        }

                        break;
                    }
                }
            }

            var memory = new List<MemoryUnit>();

            foreach (var item in _memoryItems)
            {
                for (var i = 0; i < item.Size; i++)
                    memory.Add(new MemoryUnit { Id = !item.IsEmpty ? item.Id : -1 });
            }

            long result = 0;

            for (var i = 0; i < memory.Count; i++)
                if (!memory[i].IsEmpty)
                    result += memory[i].Id * i;

            OutputHelper.ShowResult(9, 2, result);
        }
    }
}
