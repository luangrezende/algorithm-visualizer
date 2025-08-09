using AlgorithmVisualizer.Core.Sort.Interfaces;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.Core.Sort
{
    public class MergeSort : ISortingAlgorithm
    {
        public string Name => "Merge Sort";

        public void Sort(int[] array, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            MergeSortRecursive(array, 0, array.Length - 1, render, cancellationToken);
        }

        private void MergeSortRecursive(int[] array, int left, int right, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSortRecursive(array, left, middle, render, cancellationToken);

                MergeSortRecursive(array, middle + 1, right, render, cancellationToken);

                Merge(array, left, middle, right, render, cancellationToken);
            }
        }

        private void Merge(int[] array, int left, int middle, int right, Action<int[], int, int> render, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++) leftArray[i] = array[left + i];
            for (int j = 0; j < n2; j++) rightArray[j] = array[middle + 1 + j];

            int iIndex = 0, jIndex = 0, kIndex = left;

            while (iIndex < n1 && jIndex < n2)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (leftArray[iIndex] <= rightArray[jIndex])
                {
                    array[kIndex] = leftArray[iIndex];
                    iIndex++;
                }
                else
                {
                    array[kIndex] = rightArray[jIndex];
                    jIndex++;
                }

                render(array, kIndex, -1);
                Thread.Sleep(AlgorithmSettings.Delay);
                kIndex++;
            }

            while (iIndex < n1)
            {
                cancellationToken.ThrowIfCancellationRequested();

                array[kIndex] = leftArray[iIndex];
                render(array, kIndex, -1);
                Thread.Sleep(AlgorithmSettings.Delay);
                iIndex++;
                kIndex++;
            }

            while (jIndex < n2)
            {
                cancellationToken.ThrowIfCancellationRequested();

                array[kIndex] = rightArray[jIndex];
                render(array, kIndex, -1);
                Thread.Sleep(AlgorithmSettings.Delay);
                jIndex++;
                kIndex++;
            }
        }
    }
}
