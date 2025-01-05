namespace AlgorithmVisualizer.Sort.Interfaces
{
    public interface ISortingAlgorithm
    {
        string Name { get; }

        void Sort(int[] array, Action<int[], int, int> render);
    }
}
