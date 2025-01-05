using System.Diagnostics;
using AlgorithmVisualizer.Sort.Interfaces;
using AlgorithmVisualizer.Sort;
using AlgorithmVisualizer.Utils;

class Program
{
    static void Main(string[] args)
    {
        int arraySize = 100;
        int[] array = ArrayGenerator.GenerateRandomArray(arraySize, 1, arraySize);

        ISortingAlgorithm sortingAlgorithm = GetSortingAlgorithm();

        VisualizeSorting(array, sortingAlgorithm);
    }

    static ISortingAlgorithm GetSortingAlgorithm()
    {
        Console.WriteLine("Choose a sorting algorithm:");
        Console.WriteLine("1. Bubble Sort");
        Console.WriteLine("2. Quick Sort");
        Console.WriteLine("3. Insertion Sort");
        Console.WriteLine("4. Merge Sort");
        Console.WriteLine("5. Heap Sort");
        Console.WriteLine("6. Selection Sort");

        while (true)
        {
            Console.Write("Enter the number of the desired algorithm: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return new BubbleSort();
                case "2":
                    return new QuickSort();
                case "3":
                    return new InsertionSort();
                case "4":
                    return new MergeSort();
                case "5":
                    return new HeapSort();
                case "6":
                    return new SelectionSort();
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void VisualizeSorting(int[] array, ISortingAlgorithm sortingAlgorithm)
    {
        Console.Clear();

        Stopwatch stopwatch = new();
        stopwatch.Start();

        sortingAlgorithm.Sort(array, (arr, activeIndex, adjustedIndex) =>
        {
            ConsoleRenderer.RenderHeader(sortingAlgorithm.Name, stopwatch.Elapsed);
            ConsoleRenderer.RenderArray(arr, activeIndex, adjustedIndex);
        });

        stopwatch.Stop();
        ConsoleRenderer.RenderHeader(sortingAlgorithm.Name, stopwatch.Elapsed);
        ConsoleRenderer.RenderArray(array, -1, -1);
    }
}
