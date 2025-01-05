using System;
using AlgorithmVisualizer.Sort.Interfaces;

namespace AlgorithmVisualizer.Sort
{
    public class SelectionSort : ISortingAlgorithm
    {
        public string Name => "Selection Sort";

        public void Sort(int[] array, Action<int[], int, int> render)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    render(array, j, minIndex);
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                        render(array, j, minIndex);
                    }
                }

                Swap(array, i, minIndex);
                render(array, i, minIndex);
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
