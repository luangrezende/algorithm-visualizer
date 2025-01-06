namespace AlgorithmVisualizer.Utils
{
    public static class ArrayGenerator
    {
        public static int[] GenerateShuffledArray(int size)
        {
            var array = Enumerable.Range(1, size).ToArray();

            Random random = new();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }

            return array;
        }
    }

}
