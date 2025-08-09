# Algorithm Visualizer

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?style=flat-square&logo=windows)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)

**An educational sorting algorithm visualizer built with .NET and WPF**

Interactive, real-time visualizations designed for students, educators, and developers to understand how sorting algorithms work.

## Features

- **Step-by-step visualization** with real-time algorithm progression
- **Performance metrics** showing comparisons, swaps, and time complexity
- **Multiple sorting algorithms** with detailed analysis
- **Customizable settings** for array size, speed, and data patterns
- **Clean, modern interface** following Windows design guidelines

## Getting Started

### Prerequisites
- Windows 10/11 (x64)
- .NET 8.0 SDK (for development) or Runtime (for running pre-built version)

### Running the Application

#### Option 1: Download Pre-built Release
1. Download from [Releases page](https://github.com/luangrezende/algorithm-visualizer/releases)
2. Extract and run `AlgorithmVisualizer.exe`

#### Option 2: Build from Source
```powershell
# Clone the repository
git clone https://github.com/luangrezende/algorithm-visualizer.git
cd algorithm-visualizer

# Restore dependencies and build
dotnet restore
dotnet build

# Run the application
dotnet run --project AlgorithmVisualizer.UI
```

## Supported Algorithms

| Algorithm | Time Complexity | Space | Stability |
|-----------|----------------|-------|-----------|
| **Bubble Sort** | O(n²) | O(1) | ✅ Stable |
| **Quick Sort** | O(n log n) avg | O(log n) | ❌ Unstable |
| **Merge Sort** | O(n log n) | O(n) | ✅ Stable |
| **Selection Sort** | O(n²) | O(1) | ❌ Unstable |
| **Heap Sort** | O(n log n) | O(1) | ❌ Unstable |
| **Insertion Sort** | O(n²) | O(1) | ✅ Stable |

Each algorithm includes real-time visualization of comparisons, swaps, and current positions during sorting.

## Contributing

Contributions are welcome! Here's how you can help:

1. **Fork** the repository
2. **Create** a feature branch: `git checkout -b feature/your-feature`
3. **Make** your changes and add tests
4. **Commit** with clear messages: `git commit -m 'Add new feature'`
5. **Push** to your branch: `git push origin feature/your-feature`
6. **Open** a Pull Request

### Adding New Algorithms

To add a new sorting algorithm:

1. Create a new class implementing `ISortingAlgorithm`:
```csharp
public class YourNewSort : ISortingAlgorithm
{
    public string Name => "Your Algorithm Name";
    public string Description => "Brief description";
    
    public void Sort(int[] array, Action<int[], int, int> render, 
                    CancellationToken cancellationToken)
    {
        // Your algorithm implementation
        // Call render(array, currentIndex, comparedIndex) for visualization
    }
}
```

2. Register it in `SortingController.GetAvailableAlgorithms()`

For bugs or feature requests, please open an [issue](https://github.com/luangrezende/algorithm-visualizer/issues).

## License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

## Technologies Used

- **.NET 8.0** - Modern framework
- **WPF** - Windows desktop application framework  
- **C# 12.0** - Latest language features

---

Made with ❤️ for students, educators, and developers

[Report Bug](https://github.com/luangrezende/algorithm-visualizer/issues) • [Request Feature](https://github.com/luangrezende/algorithm-visualizer/issues)