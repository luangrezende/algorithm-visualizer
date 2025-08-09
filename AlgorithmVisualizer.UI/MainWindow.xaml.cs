using System.Windows;
using AlgorithmVisualizer.UI.Controllers;
using AlgorithmVisualizer.UI.Models;
using AlgorithmVisualizer.UI.Services;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.UI
{
    public partial class MainWindow : Window
    {
        private bool _isRunning = false;
        private CancellationTokenSource? _cancellationTokenSource;
        private SortingController _sortingController;

        private PathfindingModel _pathModel;
        private GridRenderService _pathRenderer;
        private PathfindingController _pathController;

        public MainWindow()
        {
            InitializeComponent();

            _sortingController = new SortingController(VisualizerCanvas, AlgorithmSelector);

            _pathModel = new PathfindingModel();
            _pathRenderer = new GridRenderService(PathfindingCanvas, _pathModel);
            _pathController = new PathfindingController(PathfindingCanvas, PathfindingAlgorithmSelector);

            InitializeEvents();
            InitializePathfinding();
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

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
            
            _isRunning = true;
            UpdateButtonStates();

            int[] data = ArrayGenerator.GenerateShuffledArray(100);

            var algorithm = _sortingController.GetSelectedAlgorithm();
            if (algorithm == null)
            {
                ShowMessage("Please select an algorithm.", "Warning", MessageBoxImage.Warning);
                ResetExecutionState();
                return;
            }

            try
            {
                await _sortingController.RunSort(algorithm, data, _cancellationTokenSource.Token);
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
            try
            {
                StopExecution();
                ShowMessage("Algorithm execution stopped.", "Info", MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error stopping execution: {ex.Message}", "Error", MessageBoxImage.Error);
            }
        }

        private void StopExecution()
        {
            try
            {
                if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource.Cancel();
                }
                ResetExecutionState();
            }
            catch (ObjectDisposedException)
            {
                ResetExecutionState();
            }
        }

        private void ResetExecutionState()
        {
            _isRunning = false;
            UpdateButtonStates();
            
            try
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
            catch (ObjectDisposedException)
            {
                _cancellationTokenSource = null;
            }
        }

        private void UpdateButtonStates()
        {
            StartButton.IsEnabled = !_isRunning;
            StopButton.IsEnabled = _isRunning;
        }

        private void ShowMessage(string message, string title, MessageBoxImage icon)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, icon);
        }

        private void InitializePathfinding()
        {
            StartPathfindingButton.Click += async (s, e) =>
            {
                var algorithm = _pathController.GetSelectedAlgorithm();
                if (algorithm == null)
                {
                    ShowMessage("Please select a pathfinding algorithm.", "Warning", MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    _cancellationTokenSource?.Dispose();
                    _cancellationTokenSource = new CancellationTokenSource();
                    
                    await _pathController.RunPathfinding(algorithm, _cancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    ShowMessage("Pathfinding cancelled.", "Info", MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ShowMessage($"Pathfinding error: {ex.Message}", "Error", MessageBoxImage.Error);
                }
            };

            ResetPathfindingButton.Click += (s, e) =>
            {
                try
                {
                    _pathController.GenerateValidMaze();
                    _pathController.Renderer.DrawGrid();
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error resetting pathfinding: {ex.Message}", "Error", MessageBoxImage.Error);
                }
            };

            PathfindingCanvas.Loaded += (s, e) => 
            {
                try
                {
                    _pathController.Renderer.DrawGrid();
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error initializing pathfinding grid: {ex.Message}", "Error", MessageBoxImage.Error);
                }
            };
        }

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
            
            base.OnClosed(e);
        }
    }
}
