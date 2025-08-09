using AlgorithmVisualizer.UI.Services;
using AlgorithmVisualizer.Core.Sort;
using AlgorithmVisualizer.Core.Sort.Interfaces;
using System.Windows.Controls;

namespace AlgorithmVisualizer.UI.Controllers
{
    public class SortingController
    {
        private readonly Canvas _canvas;
        private readonly ComboBox _algorithmSelector;
        private readonly ArrayRenderService _renderService;

        public SortingController(Canvas canvas, ComboBox algorithmSelector)
        {
            _canvas = canvas;
            _algorithmSelector = algorithmSelector;
            _renderService = new ArrayRenderService(canvas);
        }

        public ISortingAlgorithm? GetSelectedAlgorithm()
        {
            return (_algorithmSelector.SelectedItem as ComboBoxItem)?.Content.ToString() switch
            {
                "Bubble Sort" => new BubbleSort(),
                "Quick Sort" => new QuickSort(),
                "Merge Sort" => new MergeSort(),
                "Selection Sort" => new SelectionSort(),
                "Heap Sort" => new HeapSort(),
                "Insertion Sort" => new InsertionSort(),
                _ => null
            };
        }

        public async Task RunSort(ISortingAlgorithm algorithm, int[] data, CancellationToken token)
        {
            try
            {
                await Task.Run(() =>
                {
                    algorithm.Sort(data, (array, i1, i2) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            try
                            {
                                _renderService.RenderArray(array, i1, i2);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Render error: {ex.Message}");
                            }
                        });
                    }, token);
                }, token);
            }
            catch (OperationCanceledException)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        _canvas.Children.Clear();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Canvas clear error: {ex.Message}");
                    }
                });

                throw;
            }
        }
    }
}
