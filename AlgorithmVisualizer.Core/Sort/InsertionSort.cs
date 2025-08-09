using AlgorithmVisualizer.Core.Sort.Interfaces;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.Core.Sort
{
    public class InsertionSort : ISortingAlgorithm
    {
        public string Name => "Insertion Sort";

        public void Sort(int[] array, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            for (int i = 1; i < array.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                int key = array[i];
                int j = i - 1;

                render(array, i, -1);
                Thread.Sleep(AlgorithmSettings.Delay);

                while (j >= 0 && array[j] > key)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    array[j + 1] = array[j];
                    render(array, j, j + 1);
                    Thread.Sleep(AlgorithmSettings.Delay);
                    j--;
                }

                array[j + 1] = key;
                render(array, j + 1, i);
                Thread.Sleep(AlgorithmSettings.Delay);
            }
        }
    }
}
