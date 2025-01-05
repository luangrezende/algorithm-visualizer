using AlgorithmVisualizer.Sort.Interfaces;

namespace AlgorithmVisualizer.Sort
{
    public class InsertionSort : ISortingAlgorithm
    {
        public string Name => "Insertion Sort";

        public void Sort(int[] array, Action<int[], int, int> render)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                render(array, i, -1);

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    render(array, j, j + 1);
                    j--;
                }
                array[j + 1] = key;
                render(array, j + 1, i);
            }
        }
    }
}
