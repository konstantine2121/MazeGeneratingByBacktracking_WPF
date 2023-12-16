using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MazeGenerating.Data;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace MazeGeneratingByBacktracking_WPF.Utils
{
    internal class MazeDrawer
    {
        /*
        public Image CreateImpage(Maze maze, Color floor, Color wall, uint cellSize)
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            //geometryGroup.Children.A

            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            //aGeometryDrawing.Geometry = new EllipseGeometry(new Point(50, 50), 50, 50);
            aGeometryDrawing.Pen = new Pen(Brushes.Red, 10);
            aGeometryDrawing.Brush = Brushes.Blue;
            //DrawingImage geometryImage = new DrawingImage(aGeometryDrawing);
            DrawingImage geometryImage = new DrawingImage();


            Image anImage = new Image();
            anImage.Source = geometryImage;
            return anImage;
        }
        */

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
            rect.Width = cellSize;

            Canvas.SetLeft(rect, column * cellSize);
            Canvas.SetTop(rect, row * cellSize);

            return rect;
        }       
    }
}
