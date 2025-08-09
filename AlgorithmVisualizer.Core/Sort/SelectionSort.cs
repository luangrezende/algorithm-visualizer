using AlgorithmVisualizer.Core.Sort.Interfaces;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.Core.Sort
{
    public class SelectionSort : ISortingAlgorithm
    {
        public string Name => "Selection Sort";

        public void Sort(int[] array, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    render(array, j, minIndex);
                    Thread.Sleep(AlgorithmSettings.Delay);

                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                        render(array, j, minIndex);
                        Thread.Sleep(AlgorithmSettings.Delay);
                    }
                }

                Swap(array, i, minIndex);
                render(array, i, minIndex);
                Thread.Sleep(AlgorithmSettings.Delay);
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
