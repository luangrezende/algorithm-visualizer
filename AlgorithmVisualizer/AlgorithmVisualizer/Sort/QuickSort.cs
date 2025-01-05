using AlgorithmVisualizer.Sort.Interfaces;

namespace AlgorithmVisualizer.Sort
{
    public class QuickSort : ISortingAlgorithm
    {
        public string Name => "Quick Sort";

        public void Sort(int[] array, Action<int[], int, int> render)
        {
            QuickSortRecursive(array, 0, array.Length - 1, render);
        }

        private void QuickSortRecursive(int[] array, int low, int high, Action<int[], int, int> render)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, render);

                QuickSortRecursive(array, low, pivotIndex - 1, render);
                QuickSortRecursive(array, pivotIndex + 1, high, render);
            }
        }

        private int Partition(int[] array, int low, int high, Action<int[], int, int> render)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                render(array, j, high);

                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                    render(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            render(array, i + 1, high);

            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}
