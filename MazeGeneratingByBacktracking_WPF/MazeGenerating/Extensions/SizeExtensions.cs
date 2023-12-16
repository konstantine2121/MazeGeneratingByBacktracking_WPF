using MazeGenerating.Data;

namespace MazeGenerating.Extensions
{
    internal static class SizeExtensions
    {
        public static Size AddWalls(this Size size)
        {
            var width = size.Width * 2 + 1;
            var height = size.Height * 2 + 1;

            return new Size(width, height);
        }
    }
}
