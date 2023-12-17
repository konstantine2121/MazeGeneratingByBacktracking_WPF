using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MazeGenerating.Data;
using Color = System.Windows.Media.Color;

namespace MazeGeneratingByBacktracking_WPF.Utils
{
    internal class MazeDrawer
    {

        public Rectangle[] CreateCells(Maze maze, uint cellSize, Color floor, Color wall)
        {
            var cells = new List<Rectangle>();
            var floorBrush = new SolidColorBrush(floor);
            var wallBrush = new SolidColorBrush(wall);

            for (int row = 0; row < maze.Height; row++)
            {
                for (int column = 0; column < maze.Width; column++)
                {
                    var brush = maze[column, row] == CellType.Floor ? floorBrush : wallBrush;
                    cells.Add(CreateRectangle(row, column, cellSize, brush));
                }
            }

            return cells.ToArray();
        }

        private Rectangle CreateRectangle(int row, int column, uint cellSize, SolidColorBrush solidColorBrush)
        {
            var rect = new Rectangle();
            rect.Fill = solidColorBrush;
            rect.Width = cellSize;
            rect.Height = cellSize;

            Canvas.SetLeft(rect, column * cellSize);
            Canvas.SetTop(rect, row * cellSize);

            return rect;
        }
    }
}
