using System.Diagnostics;
using MazeGenerating.DebugViews;

namespace MazeGenerating.Data
{
    [DebuggerTypeProxy(typeof(MazeDebugView))]
    internal class Maze
    {
        private readonly CellType[,] _cells;

        public Maze(Size size)
        {
            _cells = new CellType[size.Height, size.Width];
        }

        public int Height => _cells.GetLength(0);
        public int Width => _cells.GetLength(1);

        public CellType this[int left, int top]
        {
            get => _cells[top, left];
            set => _cells[top, left] = value;
        }

        public bool Contains(Point point)
        {
            return 0 <= point.X && point.X < Width &&
                0 <= point.Y && point.Y < Height;
        }
    }
}
