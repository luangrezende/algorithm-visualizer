
# Algorithm Visualizer

This project is a **console-based algorithm visualizer** that demonstrates sorting algorithms in action by rendering visual representations of the sorting process. It supports various sorting algorithms and provides a dynamic way to observe their behavior step-by-step.

---

## Features

- **Sorting Algorithms**
  - Bubble Sort
  - Quick Sort
  - Merge Sort
  - Insertion Sort
  - Selection Sort
  - Heap Sort

- **Dynamic Visualizations**
  - Bars are rendered vertically in the console.
  - Real-time updates highlight active comparisons and swaps.
  - Execution time displayed after sorting is completed.

- **Customizable**
  - Array size and value ranges can be modified.
  - Add new sorting algorithms easily by following the provided interface.

---

## Getting Started

### Prerequisites

- **.NET 6.0 or later** installed on your machine.
- A terminal or console that supports Unicode characters (e.g., Windows Terminal).

### Cloning the Repository

```bash
git clone https://github.com/luangrezende/algorithm-visualizer.git
cd algorithm-visualizer
```

### Running the Application

1. Open the project in your favorite IDE (e.g., Visual Studio, JetBrains Rider, or VS Code).
2. Build and run the project.
3. Follow the console instructions to select a sorting algorithm.

---

## Usage

### Example Output

Upon running the program, you'll see:

```text
Choose a sorting algorithm:
1. Bubble Sort
2. Quick Sort
3. Merge Sort
Enter the number of the desired algorithm: 2
```

After selection, the sorting process will start, and you'll see the visualization in the console:

```text
Algorithm: Quick Sort
Execution Time: 2.53 seconds
--------------------------------------------------
████
█████
██████
...
```

---

## Project Structure

```
AlgorithmVisualizer/
├── Program.cs                      // Main entry point
├── Utils/
│   ├── ArrayGenerator.cs           // Generates arrays for sorting
│   ├── ArrayRenderer.cs            // Renders visual representations of arrays
├── Sort/
│   ├── Interfaces/
│   │   ├── ISortingAlgorithm.cs    // Interface for sorting algorithms
│   ├── BubbleSort.cs               // Implementation of Bubble Sort
│   ├── QuickSort.cs                // Implementation of Quick Sort
│   ├── MergeSort.cs                // Implementation of Merge Sort
│   ├── InsertionSort.cs            // Implementation of Insertion Sort
│   ├── SelectionSort.cs            // Implementation of Selection Sort
│   ├── HeapSort.cs                 // Implementation of Heap Sort
```

---

## How to Add a New Sorting Algorithm

1. Create a new file in the `Sort` folder (e.g., `NewSort.cs`).
2. Implement the `ISortingAlgorithm` interface.

```csharp
using AlgorithmVisualizer.Sort.Interfaces;

public class NewSort : ISortingAlgorithm
{
    public string Name => "New Sort";

    public void Sort(int[] array, Action<int[], int, int> render)
    {
        // Sorting logic here
        // Call render(array, activeIndex, adjustedIndex) to visualize the process
    }
}
```

3. Add the new algorithm to the selection menu in `Program.cs`:

```csharp
case "7":
    return new NewSort();
```

---

## Customization

- Modify `maxHeight` in `ArrayRenderer.cs` to adjust the visual height of the bars.
- Update `ArrayGenerator.cs` to change the size or range of the generated array.

---

## Future Enhancements

- Support for more complex algorithms (e.g., Radix Sort, Shell Sort).
- Graphical user interface (GUI) for enhanced visualization.
- More visual styles for representing data.
- Support for custom input arrays.

---

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests for improvements or new features.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

---