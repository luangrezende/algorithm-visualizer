using System;

namespace AlgorithmVisualizer.Utils
{
    public static class ArrayGenerator
    {
        public static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }
    }
}
