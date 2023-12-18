using System.Windows;
using System.Windows.Media;
using MazeGenerating.Data;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

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

            var canvasSize = GetCanvasSize(maze, cellSize);

            drawingContext.DrawRectangle(
                brush: floorBrush,
                pen: null,
                rectangle: new Rect(canvasSize));

            for (int i = 0; i < maze.Height; i++)
            {
                for (int j = 0; j < maze.Width; j++)
                {
                    var cellType = maze[j, i];

                    if (cellType == CellType.Wall)
                    {
                        drawingContext.DrawRectangle(
                            brush: wallBrush,
                            pen: null,
                            rectangle: new Rect(
                                new Point(j * cellSize, i * cellSize),
                                new Size(cellSize, cellSize)));
                    }
                }
            }
        }

        private Size GetCanvasSize(Maze maze, uint cellSize)
        {
            return new Size(
                maze.Width * cellSize,
                maze.Height * cellSize);
        }
    }
}
