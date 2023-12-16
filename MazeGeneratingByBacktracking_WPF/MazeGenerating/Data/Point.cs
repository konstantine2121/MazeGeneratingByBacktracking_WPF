using System;

namespace MazeGenerating.Data
{
    internal struct Point
    {
        public Point(int x, int y)
        {
            Y = y;
            X = x;
        }

        public int Y { get; set; }

        public int X { get; set; }


        public int GetDistance(Point other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            int seed = -1521134295;

            hashCode = hashCode * seed + X.GetHashCode();
            hashCode = hashCode * seed + Y.GetHashCode();

            return hashCode;
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !left.Equals(right);
        }

        public static Point operator +(Point left, Point right)
        {
            return new Point(
                left.X + right.X,
                left.Y + right.Y);
        }
    }
}
