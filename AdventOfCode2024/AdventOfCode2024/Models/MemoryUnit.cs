namespace AdventOfCode2024.Models
{
    internal class MemoryUnit
    {
        public int Id { get; set; } = -1;
        public bool IsEmpty => Id == -1;
    }
}
