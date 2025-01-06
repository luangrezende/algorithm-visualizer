using AlgorithmVisualizer.Sort.Interfaces;
using AlgorithmVisualizer.Utils.AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.Sort
{
    public class HeapSort : ISortingAlgorithm
    {
        public string Name => "Heap Sort";

        public void Sort(int[] array, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Heapify(array, n, i, render, cancellationToken);
            }

            for (int i = n - 1; i > 0; i--)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Swap(array, 0, i);
                render(array, i, 0);
                Thread.Sleep(AlgorithmSettings.Delay);

                Heapify(array, i, 0, render, cancellationToken);
            }
        }

        private void Heapify(int[] array, int n, int i, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                Swap(array, i, largest);
                render(array, i, largest);
                Thread.Sleep(AlgorithmSettings.Delay);

                Heapify(array, n, largest, render, cancellationToken);
            }
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
