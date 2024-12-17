namespace AdventOfCode2024.Models
{
    public class MemoryItem
    {
        public int Id { get; set; } = -1;

        public int Size { get; set; }

        public bool IsEmpty => Id == -1;
    }
}
