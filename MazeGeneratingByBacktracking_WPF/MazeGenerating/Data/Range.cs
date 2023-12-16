using System;

namespace MazeGenerating.Data
{
    internal class Range
    {
        public Range(int end) : this(0, end) { }

        public Range(int begin, int end)
        {
            if (begin > end)
            {
                throw new InvalidOperationException($"{begin} > {end} error");
            }

            Begin = begin;
            End = end;
        }

        public int Begin { get; }

        public int End { get; }

        public static bool Contains(int endRange, int value)
        {
            return new Range(endRange).Contains(value);
        }

        public bool Contains(int value)
        {
            return Begin <= value && value <= End;
        }
    }
}
