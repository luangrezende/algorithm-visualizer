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
            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
            UpdateButtonStates();
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
            VisualizerCanvas.Children.Clear();

            RenderArray(data, -1, -1);

            var selectedAlgorithm = ((ComboBoxItem)AlgorithmSelector.SelectedItem)?.Content.ToString();
            if (selectedAlgorithm == null)
            {
                MessageBox.Show("Selecione um algoritmo antes de começar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                _isRunning = false;
                UpdateButtonStates();
                return;
            }

            ISortingAlgorithm algorithm = selectedAlgorithm switch
            {
                "Bubble Sort" => new BubbleSort(),
                "Quick Sort" => new QuickSort(),
                "Merge Sort" => new MergeSort(),
                "Selection Sort" => new SelectionSort(),
                "Heap Sort" => new HeapSort(),
                "Insertion Sort" => new InsertionSort(),
                _ => throw new InvalidOperationException("Algoritmo inválido.")
            };

            try
            {
                await Task.Run(() =>
                {
                    algorithm.Sort(data, (array, index1, index2) =>
                    {
                        if (_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            throw new OperationCanceledException();
                        }

                        Dispatcher.Invoke(() =>
                        {
                            RenderArray(array, index1, index2);
                        });
                    }, _cancellationTokenSource.Token);
                }, _cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _isRunning = false;
                UpdateButtonStates();
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopExecution();
        }

        private void StopExecution()
        {
            if (_isRunning)
            {
                _cancellationTokenSource?.Cancel();
                _isRunning = false;
                VisualizerCanvas.Children.Clear();
                UpdateButtonStates();
            }
        }

        private void RenderArray(int[] array, int index1, int index2)
        {
            VisualizerCanvas.Children.Clear();

            double canvasWidth = VisualizerCanvas.ActualWidth > 0 ? VisualizerCanvas.ActualWidth : 800;
            double canvasHeight = VisualizerCanvas.ActualHeight > 0 ? VisualizerCanvas.ActualHeight : 400;

            double barWidth = canvasWidth / array.Length;
            barWidth = Math.Max(barWidth, 1);

            int maxValue = array.Length > 0 ? array.Max() : 1;
            double marginTop = 20;

            for (int i = 0; i < array.Length; i++)
            {
                Brush fillBrush;
                if (i == index1) fillBrush = Brushes.GreenYellow;
                else if (i == index2) fillBrush = Brushes.Red;
                else fillBrush = Brushes.Gray;

                var rect = new Rectangle
                {
                    Width = barWidth,
                    Height = ((array[i] / (double)maxValue) * (canvasHeight - marginTop)),
                    Fill = fillBrush,
                    Stroke = null
                };

                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                VisualizerCanvas.Children.Add(rect);
            }
        }

        private void UpdateButtonStates()
        {
            StartButton.IsEnabled = !_isRunning;
            StopButton.IsEnabled = _isRunning;
        }
    }
}
