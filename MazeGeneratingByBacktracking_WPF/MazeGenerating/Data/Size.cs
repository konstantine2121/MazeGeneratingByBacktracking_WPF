using System;

namespace MazeGenerating.Data
{
    internal struct Size
    {
        public Size(int width, int height)
        {
            if (width < 0)
            {
                throw new InvalidOperationException($"{nameof(width)} {width} < 0");
            }

            if (height < 0)
            {
                throw new InvalidOperationException($"{nameof(height)} {height} < 0");
            }

            Height = height;
            Width = width;
        }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
