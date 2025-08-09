using System;
using System.Windows;
using System.Windows.Shapes;

namespace AlgorithmVisualizer.UI.Models
{
    public class PathfindingModel
    {
        public const int Rows = 40;
        public const int Cols = 80;

        public bool[,] IsWall { get; } = new bool[Rows, Cols];
        public Rectangle[,] Grid { get; } = new Rectangle[Rows, Cols];
        public Point Start { get; set; } = new Point(0, 0);
        public Point End { get; set; } = new Point(Rows - 1, Cols - 1);
        public Random Rand { get; } = new Random();
    }
}
