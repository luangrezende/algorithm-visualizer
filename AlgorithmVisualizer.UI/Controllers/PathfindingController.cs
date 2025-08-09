using AlgorithmVisualizer.UI.Models;
using AlgorithmVisualizer.UI.Services;
using System.Windows;
using System.Windows.Controls;

namespace AlgorithmVisualizer.UI.Controllers
{
    public class PathfindingController
    {
        private readonly PathfindingModel _model;
        private readonly GridRenderService _renderer;
        private readonly ComboBox _algorithmSelector;

        public PathfindingController(Canvas canvas, ComboBox algorithmSelector)
        {
            _model = new PathfindingModel();
            _renderer = new GridRenderService(canvas, _model);
            _algorithmSelector = algorithmSelector;
        }

        public PathfindingModel Model => _model;
        public GridRenderService Renderer => _renderer;

        public object? GetSelectedAlgorithm()
        {
            return null;
        }

        public async Task RunPathfinding(object algorithm, CancellationToken token)
        {
            await Task.CompletedTask;
        }

        public void GenerateValidMaze(double density = 0.3)
        {
            for (int attempt = 0; attempt < 100; attempt++)
            {
                GenerateRandomObstacles(density);
                if (HasValidPath())
                    return;
            }

            MessageBox.Show("Não foi possível gerar um labirinto com caminho válido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            ClearObstacles();
        }

        public void GenerateRandomObstacles(double density)
        {
            for (int row = 0; row < PathfindingModel.Rows; row++)
                for (int col = 0; col < PathfindingModel.Cols; col++)
                    _model.IsWall[row, col] = (row == (int)_model.Start.X && col == (int)_model.Start.Y) ||
                                              (row == (int)_model.End.X && col == (int)_model.End.Y)
                                              ? false : _model.Rand.NextDouble() < density;
        }

        public void ClearObstacles()
        {
            for (int row = 0; row < PathfindingModel.Rows; row++)
                for (int col = 0; col < PathfindingModel.Cols; col++)
                    _model.IsWall[row, col] = false;
        }

        public bool HasValidPath()
        {
            bool[,] visited = new bool[PathfindingModel.Rows, PathfindingModel.Cols];
            var queue = new Queue<Point>();
            queue.Enqueue(_model.Start);
            visited[(int)_model.Start.X, (int)_model.Start.Y] = true;

            var directions = new[] { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1) };

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                if (point == _model.End) return true;

                foreach (var (dr, dc) in directions)
                {
                    int newRow = (int)point.X + dr;
                    int newCol = (int)point.Y + dc;

                    if (newRow >= 0 && newRow < PathfindingModel.Rows &&
                        newCol >= 0 && newCol < PathfindingModel.Cols &&
                        !_model.IsWall[newRow, newCol] && !visited[newRow, newCol])
                    {
                        visited[newRow, newCol] = true;
                        queue.Enqueue(new Point(newRow, newCol));
                    }
                }
            }

            return false;
        }
    }
}
