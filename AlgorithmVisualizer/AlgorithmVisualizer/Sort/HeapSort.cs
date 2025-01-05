using AlgorithmVisualizer.Sort.Interfaces;

namespace AlgorithmVisualizer.Sort
{
    public class HeapSort : ISortingAlgorithm
    {
        public string Name => "Heap Sort";

        public void Sort(int[] array, Action<int[], int, int> render)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i, render);

            for (int i = n - 1; i > 0; i--)
            {
                Swap(array, 0, i);
                render(array, i, 0);
                Heapify(array, i, 0, render);
            }
        }

        private void Heapify(int[] array, int n, int i, Action<int[], int, int> render)
        {
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
                Heapify(array, n, largest, render);
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
