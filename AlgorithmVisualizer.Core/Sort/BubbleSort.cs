using AlgorithmVisualizer.Core.Sort.Interfaces;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.Core.Sort
{
    public class BubbleSort : ISortingAlgorithm
    {
        public string Name => "Bubble Sort";

        public void Sort(int[] array, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    render(array, j, j + 1);
                    Thread.Sleep(100);

                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        render(array, j + 1, -1);
                        Thread.Sleep(AlgorithmSettings.Delay);
                    }
                }
            }
        }
    }
}
