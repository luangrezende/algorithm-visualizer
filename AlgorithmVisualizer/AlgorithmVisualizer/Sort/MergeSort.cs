using AlgorithmVisualizer.Sort.Interfaces;

namespace AlgorithmVisualizer.Sort
{
    public class MergeSort : ISortingAlgorithm
    {
        public string Name => "Merge Sort";

        public void Sort(int[] array, Action<int[], int, int> render)
        {
            MergeSortRecursive(array, 0, array.Length - 1, render);
        }

        private void MergeSortRecursive(int[] array, int left, int right, Action<int[], int, int> render)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSortRecursive(array, left, middle, render);
                MergeSortRecursive(array, middle + 1, right, render);

                Merge(array, left, middle, right, render);
            }
        }

        private void Merge(int[] array, int left, int middle, int right, Action<int[], int, int> render)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++) leftArray[i] = array[left + i];
            for (int j = 0; j < n2; j++) rightArray[j] = array[middle + 1 + j];

            int iIndex = 0, jIndex = 0, kIndex = left;

            while (iIndex < n1 && jIndex < n2)
            {
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
                kIndex++;
            }

            while (iIndex < n1)
            {
                array[kIndex] = leftArray[iIndex];
                render(array, kIndex, -1);
                iIndex++;
                kIndex++;
            }

            while (jIndex < n2)
            {
                array[kIndex] = rightArray[jIndex];
                render(array, kIndex, -1);
                jIndex++;
                kIndex++;
            }
        }
    }
}
