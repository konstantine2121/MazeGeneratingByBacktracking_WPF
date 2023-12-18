using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MazeGenerating.Data;
using Color = System.Windows.Media.Color;
using Size = System.Windows.Size;
using Point = System.Windows.Point;

namespace MazeGeneratingByBacktracking_WPF.Utils
{
    internal class MazeDrawer
    {
       

        public ImageSource Draw(Maze maze, uint cellSize, Color floorColor, Color wallColor)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            DrawRects(maze, cellSize, floorColor, wallColor, drawingContext);

            drawingContext.Close();

            DrawingImage drawingImageSource = new DrawingImage(drawingVisual.Drawing);
            drawingImageSource.Freeze();

            return drawingImageSource;
        }

        private void DrawRects(Maze maze, uint cellSize, Color floor, Color wall, DrawingContext drawingContext)
        {
            var floorBrush = new SolidColorBrush(floor);
            var wallBrush = new SolidColorBrush(wall);

            for (int row = 0; row < maze.Height; row++)
            {
                for (int column = 0; column < maze.Width; column++)
                {
                    var cellType = maze[column, row];

                    var brush = cellType == CellType.Floor ?
                        floorBrush :
                        wallBrush;

                    drawingContext.DrawRectangle(
                        brush: brush,
                        pen: null,
                        rectangle: CreateRect(row, column, cellSize));
                }
            }
        }

        private Rect CreateRect(int row, int column, uint cellSize)
        {
          return new Rect(
                new Point(
                    column * cellSize, 
                    row * cellSize),
                new Size(cellSize, cellSize));
        }

        private Size GetCanvasSize(Maze maze, uint cellSize)
        {
            return new Size(
                maze.Width * cellSize,
                maze.Height * cellSize);
        }
    }
}
