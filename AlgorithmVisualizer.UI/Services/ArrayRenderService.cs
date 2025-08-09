using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmVisualizer.UI.Services
{
    public class ArrayRenderService
    {
        private readonly Canvas _canvas;

        public ArrayRenderService(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void RenderArray(int[] array, int index1, int index2)
        {
            _canvas.Children.Clear();
            double canvasWidth = Math.Max(_canvas.ActualWidth, 800);
            double canvasHeight = Math.Max(_canvas.ActualHeight, 400);
            double barWidth = Math.Max(canvasWidth / array.Length, 1);
            int maxValue = array.Max();

            for (int i = 0; i < array.Length; i++)
            {
                var rect = new Rectangle
                {
                    Width = barWidth,
                    Height = (array[i] / (double)maxValue) * (canvasHeight - 20),
                    Fill = (i == index1) ? Brushes.GreenYellow : (i == index2) ? Brushes.Red : Brushes.Gray
                };
                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                _canvas.Children.Add(rect);
            }
        }
    }
}
