using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AlgorithmVisualizer.Sort;
using AlgorithmVisualizer.Sort.Interfaces;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizerGUI
{
    public partial class MainWindow : Window
    {
        private bool _isRunning = false;
        private CancellationTokenSource _cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateButtonStates();
        }

        private void InitializeEvents()
        {
            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                StopExecution();
                await Task.Delay(100);
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _isRunning = true;
            UpdateButtonStates();

            int[] data = ArrayGenerator.GenerateShuffledArray(100);
            ClearCanvas();
            RenderArray(data, -1, -1);

            var algorithm = GetSelectedAlgorithm();
            if (algorithm == null)
            {
                ShowMessage("Please select an algorithm.", "Warning", MessageBoxImage.Warning);
                ResetExecutionState();
                return;
            }

            try
            {
                await ExecuteAlgorithm(algorithm, data);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}", "Error", MessageBoxImage.Error);
            }
            finally
            {
                ResetExecutionState();
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopExecution();
        }

        private async Task ExecuteAlgorithm(ISortingAlgorithm algorithm, int[] data)
        {
            await Task.Run(() =>
            {
                algorithm.Sort(data, (array, index1, index2) =>
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                        throw new OperationCanceledException();

                    Dispatcher.Invoke(() => RenderArray(array, index1, index2));
                }, _cancellationTokenSource.Token);
            }, _cancellationTokenSource.Token);
        }

        private ISortingAlgorithm GetSelectedAlgorithm()
        {
            return ((ComboBoxItem)AlgorithmSelector.SelectedItem)?.Content.ToString() switch
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

        private void RenderArray(int[] array, int index1, int index2)
        {
            ClearCanvas();

            double canvasWidth = Math.Max(VisualizerCanvas.ActualWidth, 800);
            double canvasHeight = Math.Max(VisualizerCanvas.ActualHeight, 400);
            double barWidth = Math.Max(canvasWidth / array.Length, 1);
            int maxValue = array.Max();

            for (int i = 0; i < array.Length; i++)
            {
                var rect = CreateRectangle(array[i], maxValue, barWidth, canvasHeight - 20, i == index1, i == index2);
                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                VisualizerCanvas.Children.Add(rect);
            }
        }

        private Rectangle CreateRectangle(int value, int maxValue, double width, double maxHeight, bool isActive, bool isCompared)
        {
            var fillBrush = isActive ? Brushes.GreenYellow : isCompared ? Brushes.Red : Brushes.Gray;

            return new Rectangle
            {
                Width = width,
                Height = (value / (double)maxValue) * maxHeight,
                Fill = fillBrush,
                Stroke = null
            };
        }

        private void ClearCanvas()
        {
            VisualizerCanvas.Children.Clear();
        }

        private void UpdateButtonStates()
        {
            StartButton.IsEnabled = !_isRunning;
            StopButton.IsEnabled = _isRunning;
        }

        private void StopExecution()
        {
            _cancellationTokenSource?.Cancel();
            ClearCanvas();
        }

        private void ResetExecutionState()
        {
            _isRunning = false;
            UpdateButtonStates();
        }

        private void ShowMessage(string message, string title, MessageBoxImage icon)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, icon);
        }
    }
}
