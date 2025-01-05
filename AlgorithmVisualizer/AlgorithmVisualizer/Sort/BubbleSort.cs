using System;
using AlgorithmVisualizer.Sort.Interfaces;

namespace AlgorithmVisualizer.Sort
{
    public class BubbleSort : ISortingAlgorithm
    {
        public string Name => "Bubble Sort";

        public void Sort(int[] array, Action<int[], int, int> render)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    render(array, j, j + 1);

                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        render(array, j + 1, -1);
                    }
                }
            }
        }
    }
}
