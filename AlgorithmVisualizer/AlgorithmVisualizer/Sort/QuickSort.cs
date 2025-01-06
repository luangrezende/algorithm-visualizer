using AlgorithmVisualizer.Sort.Interfaces;
using AlgorithmVisualizer.Utils.AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.Sort
{
    public class QuickSort : ISortingAlgorithm
    {
        public string Name => "Quick Sort";

        public void Sort(int[] array, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            QuickSortRecursive(array, 0, array.Length - 1, render, cancellationToken);
        }

        private void QuickSortRecursive(int[] array, int low, int high, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, render, cancellationToken);

                QuickSortRecursive(array, low, pivotIndex - 1, render, cancellationToken);
                QuickSortRecursive(array, pivotIndex + 1, high, render, cancellationToken);
            }
        }

        private int Partition(int[] array, int low, int high, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                render(array, j, high);
                Thread.Sleep(AlgorithmSettings.Delay);

                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                    render(array, i, j);
                    Thread.Sleep(AlgorithmSettings.Delay);
                }
            }

            Swap(array, i + 1, high);
            render(array, i + 1, high);
            Thread.Sleep(AlgorithmSettings.Delay);

            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}
