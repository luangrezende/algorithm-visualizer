# Algorithm Visualizer

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?style=flat-square&logo=windows)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

A **sorting algorithm visualizer** built with **.NET 8 and WPF**, focused on **clarity, correctness, and real-time introspection** of algorithm behavior.

The project emphasizes **deterministic execution**, **explicit state transitions**, and **accurate performance metrics**, rather than purely visual effects.

---

## Overview

Algorithm Visualizer provides an interactive desktop application for exploring how common sorting algorithms operate internally.

Key goals:
- Make algorithm behavior observable step-by-step
- Expose comparisons, swaps, and execution flow in real time
- Keep algorithm implementations clean and framework-agnostic
- Separate visualization concerns from sorting logic

The application is intended as a **learning and reference tool**, not a benchmarking suite.

---

## Features

- Step-by-step execution with real-time rendering  
- Visual indication of comparisons and swaps  
- Metrics tracking (operations, steps, execution time)  
- Adjustable array size and execution speed  
- Multiple sorting algorithms under a common abstraction  
- Clean WPF UI following native Windows patterns  

---

## Supported Algorithms

| Algorithm | Time Complexity | Space | Stability |
|---------|----------------|-------|----------|
| Bubble Sort | O(n²) | O(1) | Stable |
| Insertion Sort | O(n²) | O(1) | Stable |
| Selection Sort | O(n²) | O(1) | Unstable |
| Merge Sort | O(n log n) | O(n) | Stable |
| Quick Sort | O(n log n) avg | O(log n) | Unstable |
| Heap Sort | O(n log n) | O(1) | Unstable |

Each implementation exposes its internal operations to the visualization layer through a controlled rendering callback.

---

## Architecture Notes

- Sorting algorithms implement a shared interface (`ISortingAlgorithm`)
- Visualization is driven by explicit render callbacks
- Cancellation tokens allow controlled interruption and reset
- UI logic is isolated from algorithm execution
- Execution flow favors determinism over raw speed

This design makes it easy to add new algorithms without modifying existing logic.

---

## Getting Started

### Requirements
- Windows 10 / 11
- .NET 8 Runtime (or SDK for development)

### Running from Release

1. Download the latest release from:
   https://github.com/luangrezende/algorithm-visualizer/releases
2. Extract and run `AlgorithmVisualizer.exe`

---

### Building from Source

```powershell
git clone https://github.com/luangrezende/algorithm-visualizer.git
cd algorithm-visualizer

dotnet restore
dotnet build
dotnet run --project AlgorithmVisualizer.UI
```

---

## Extending the Application

### Adding a New Algorithm

To add a new sorting algorithm, implement the shared interface:

```csharp
public class CustomSort : ISortingAlgorithm
{
    public string Name => "Custom Sort";
    public string Description => "Short algorithm description";

    public void Sort(
        int[] array,
        Action<int[], int, int> render,
        CancellationToken cancellationToken)
    {
        // Algorithm logic
        // Call render(array, indexA, indexB) to trigger visualization
    }
}
```

Then register it in the algorithm factory/controller.

---

## Project Scope

This project is not intended as:
- A high-performance sorting benchmark
- A competitive programming tool
- A UI-heavy animation demo

It is intended as:
- A practical learning aid
- A reference for algorithm visualization patterns
- A clean example of WPF + .NET 8 application structure

---

## Technologies

- **.NET 8**
- **C# 12**
- **WPF**
- **MVVM-inspired separation (lightweight)**

---

## License

MIT License.
