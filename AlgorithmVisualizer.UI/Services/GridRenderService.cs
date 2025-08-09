using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AlgorithmVisualizer.UI.Models;

namespace AlgorithmVisualizer.UI.Services
{
    public class GridRenderService
    {
        private readonly Canvas _canvas;
        private readonly PathfindingModel _model;

        public GridRenderService(Canvas canvas, PathfindingModel model)
        {
            _canvas = canvas;
            _model = model;
        }

        public void DrawGrid()
        {
            _canvas.Children.Clear();
            double cellWidth = 1154.0 / PathfindingModel.Cols;
            double cellHeight = 500.0 / PathfindingModel.Rows;

            for (int row = 0; row < PathfindingModel.Rows; row++)
            {
                for (int col = 0; col < PathfindingModel.Cols; col++)
                {
                    var rect = new Rectangle
                    {
                        Width = cellWidth - 1,
                        Height = cellHeight - 1,
                        Fill = _model.IsWall[row, col] ? Brushes.DarkGray : Brushes.White,
                        Stroke = Brushes.LightGray
                    };

                    _canvas.Children.Add(rect);
                    Canvas.SetLeft(rect, col * cellWidth);
                    Canvas.SetTop(rect, row * cellHeight);
                    _model.Grid[row, col] = rect;
                }
            }

            _model.Grid[(int)_model.Start.X, (int)_model.Start.Y].Fill = Brushes.Blue;
            _model.Grid[(int)_model.End.X, (int)_model.End.Y].Fill = Brushes.Red;
        }
    }
}
