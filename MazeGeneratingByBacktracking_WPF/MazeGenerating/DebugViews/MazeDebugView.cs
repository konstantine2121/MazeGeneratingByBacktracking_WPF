using System.Text;
using MazeGenerating.Data;

namespace MazeGenerating.DebugViews
{
    internal class MazeDebugView
    {
        private const char Wall = '█';
        private const char Floor = ' ';

        private readonly Maze _maze;

        public MazeDebugView(Maze maze)
        {
            _maze = maze;
        }

        public string View
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int y = 0; y < _maze.Height; y++)
                {
                    AddRowText(stringBuilder, y);
                }

                return stringBuilder.ToString();
            }
        }

        private void AddRowText(StringBuilder stringBuilder, int y)
        {
            for (int x = 0; x < _maze.Width; x++)
            {
                stringBuilder.Append(_maze[x, y] == CellType.Wall ? Wall : Floor);
            }

            stringBuilder.AppendLine();
        }
    }
}
