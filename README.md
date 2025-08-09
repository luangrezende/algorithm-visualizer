# Algorithm Visualizer

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?style=flat-square&logo=windows)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)
[![Release](https://img.shields.io/github/v/release/your-username/algorithm-visualizer?style=flat-square)](https://github.com/your-username/algorithm-visualizer/releases)
[![Build](https://img.shields.io/github/actions/workflow/status/your-username/algorithm-visualizer/release.yml?style=flat-square)](https://github.com/your-username/algorithm-visualizer/actions)

**A professional, educational sorting algorithm visualizer built with modern .NET and WPF**

Transform your understanding of algorithms through interactive, real-time visualizations designed for students, educators, and developers.

## Download

### Latest Release
Download the latest pre-built executable from our [Releases page](https://github.com/your-username/algorithm-visualizer/releases).

**Requirements:**
- Windows 10/11 (x64)
- .NET 8.0 Runtime (automatically included in release)

### Installation Options
1. **Portable Executable**: Download and run directly
2. **Self-contained**: No .NET installation required
3. **Framework-dependent**: Smaller size, requires .NET 8.0 Runtime

## Key Features

### Educational Focus
- **Step-by-step execution** with detailed algorithm progression
- **Performance metrics** including comparisons, swaps, and time complexity visualization  
- **Algorithm comparison** side-by-side analysis capabilities
- **Educational tooltips** explaining each algorithm's characteristics

### Professional Interface
- **Clean, modern UI** following Windows design guidelines
- **Responsive controls** with intuitive operation
- **Real-time visualization** with smooth animations
- **Customizable parameters** for array size, speed, and data distribution

### Technical Excellence
- **High performance** optimized for large datasets
- **Thread-safe operations** with proper cancellation support
- **Memory efficient** with minimal resource consumption
- **Extensible architecture** for easy algorithm integration

## Quick Start

### For End Users

1. **Download** the latest release from the [Releases page](https://github.com/your-username/algorithm-visualizer/releases)
2. **Extract** the archive to your desired location
3. **Run** `AlgorithmVisualizer.exe`

### For Developers

#### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Windows 10/11 (for WPF support)
- Visual Studio 2022, VS Code, or JetBrains Rider

#### Development Setup
```powershell
# Clone the repository
git clone https://github.com/your-username/algorithm-visualizer.git
cd algorithm-visualizer

# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the application
dotnet run --project AlgorithmVisualizer.UI
```

#### Build Executable
```powershell
# Create self-contained release
dotnet publish AlgorithmVisualizer.UI -c Release -r win-x64 --self-contained

# Create framework-dependent release
dotnet publish AlgorithmVisualizer.UI -c Release -r win-x64 --no-self-contained
```

## Supported Algorithms

### Sorting Algorithms

| Algorithm | Best Case | Average Case | Worst Case | Space | Stability | Status |
|-----------|-----------|--------------|------------|-------|-----------|---------|
| **Bubble Sort** | O(n) | O(n²) | O(n²) | O(1) | ✅ Stable | ✅ |
| **Quick Sort** | O(n log n) | O(n log n) | O(n²) | O(log n) | ❌ Unstable | ✅ |
| **Merge Sort** | O(n log n) | O(n log n) | O(n log n) | O(n) | ✅ Stable | ✅ |
| **Selection Sort** | O(n²) | O(n²) | O(n²) | O(1) | ❌ Unstable | ✅ |
| **Heap Sort** | O(n log n) | O(n log n) | O(n log n) | O(1) | ❌ Unstable | ✅ |
| **Insertion Sort** | O(n) | O(n²) | O(n²) | O(1) | ✅ Stable | ✅ |

### Algorithm Characteristics

#### **Performance Optimized**
- **Quick Sort**: Fastest average-case performance for random data
- **Merge Sort**: Guaranteed O(n log n) with stable sorting
- **Heap Sort**: Optimal worst-case performance with minimal memory

#### **Educational Value**
- **Bubble Sort**: Demonstrates basic comparison-based sorting
- **Selection Sort**: Shows selection-based algorithm principles  
- **Insertion Sort**: Illustrates incremental building approach

### Visualization Features
- **Real-time step tracking** with detailed operation counts
- **Color-coded elements** indicating current operations
- **Adaptive speed control** for educational pacing
- **Cancellation support** for long-running operations

## Architecture

The project implements a **clean, layered architecture** following SOLID principles and separation of concerns:

```
AlgorithmVisualizer/
├── AlgorithmVisualizer.Core/      # Business Logic Layer
│   └── Sort/                         # Algorithm implementations
│       ├── Interfaces/               # Contracts & abstractions
│       │   └── ISortingAlgorithm.cs
│       ├── BubbleSort.cs            # O(n²) comparison-based sort
│       ├── QuickSort.cs             # O(n log n) divide-and-conquer
│       ├── MergeSort.cs             # O(n log n) stable sort
│       ├── SelectionSort.cs         # O(n²) selection-based sort
│       ├── HeapSort.cs              # O(n log n) heap-based sort
│       └── InsertionSort.cs         # O(n²) incremental sort
├── AlgorithmVisualizer.UI/        # Presentation Layer
│   ├── Controllers/                  # Business logic coordination
│   │   ├── SortingController.cs     # Algorithm execution control
│   │   └── PathfindingController.cs # Future pathfinding support
│   ├── Services/                     # UI services & rendering
│   │   ├── ArrayRenderService.cs    # Array visualization
│   │   └── GridRenderService.cs     # Grid-based rendering
│   ├── Models/                       # UI data models
│   │   └── PathfindingModel.cs      # Future pathfinding model
│   ├── MainWindow.xaml              # Primary application window
│   └── App.xaml                     # Application configuration
└── AlgorithmVisualizer.Utils/     # Shared Utilities Layer
    ├── AlgorithmSettings.cs          # Configuration management
    └── ArrayGenerator.cs             # Test data generation
```

### Design Patterns & Principles

#### **Core Patterns**
- **Strategy Pattern** - Pluggable algorithm implementations via `ISortingAlgorithm`
- **Observer Pattern** - Real-time UI updates during algorithm execution
- **Factory Pattern** - Algorithm instantiation and configuration
- **Command Pattern** - User interaction handling and operation queuing

#### **SOLID Principles**
- **Single Responsibility** - Each class has one clear purpose
- **Open/Closed** - Easy to extend with new algorithms without modification
- **Liskov Substitution** - All sorting algorithms are interchangeable
- **Interface Segregation** - Focused, minimal interfaces
- **Dependency Inversion** - High-level modules don't depend on low-level details

### Thread Safety & Performance
- **Async/await patterns** for non-blocking UI operations
- **CancellationToken support** for graceful operation termination
- **Memory-efficient rendering** with viewport optimization
- **Background processing** for algorithm execution

## Development

### Project Structure & Guidelines

#### **AlgorithmVisualizer.Core** - Algorithm Business Logic
- Contains all sorting algorithm implementations
- Follows the Strategy pattern with `ISortingAlgorithm` interface
- Thread-safe operations with proper cancellation support
- Comprehensive XML documentation for all public APIs

#### **AlgorithmVisualizer.UI** - Presentation Layer
- Modern WPF interface following Material Design principles
- MVVM architecture with proper data binding
- Responsive controls with accessibility support
- Comprehensive error handling and user feedback

#### **AlgorithmVisualizer.Utils** - Shared Infrastructure
- Common utilities and configuration management
- Array generation with various distribution patterns
- Performance measurement and logging utilities
- Cross-cutting concerns and helper functions

### Adding New Algorithms

1. **Implement the interface**:
   ```csharp
   public class YourNewSort : ISortingAlgorithm
   {
       public string Name => "Your New Sort";
       public string Description => "Brief description of your algorithm";
       
       public void Sort(int[] array, Action<int[], int, int> render, 
                       CancellationToken cancellationToken)
       {
           // Implementation with proper cancellation support
           for (int i = 0; i < array.Length && !cancellationToken.IsCancellationRequested; i++)
           {
               // Your sorting logic here
               render(array, i, -1); // Update visualization
               await Task.Delay(settings.DelayMs, cancellationToken);
           }
       }
   }
   ```

2. **Register the algorithm** in `SortingController.GetAvailableAlgorithms()`

3. **Add unit tests** following existing test patterns

### Development Workflow

```powershell
# Setup development environment
git clone https://github.com/your-username/algorithm-visualizer.git
cd algorithm-visualizer

# Install dependencies
dotnet restore

# Build solution
dotnet build

# Run unit tests
dotnet test

# Run application in debug mode
dotnet run --project AlgorithmVisualizer.UI --configuration Debug

# Create release build
dotnet publish AlgorithmVisualizer.UI -c Release -r win-x64 --self-contained

# Clean build artifacts
dotnet clean
```

### Code Quality Standards
- **Code Analysis**: StyleCop and FxCop analyzers enabled
- **Testing**: Unit tests with minimum 80% code coverage
- **Documentation**: XML documentation for all public APIs
- **Performance**: Benchmarking for algorithm implementations
- **Security**: Static analysis with security rule sets

## Contributing

Contributions are welcome! Feel free to fork the repository, make your changes, and submit a pull request.

For bugs or feature requests, please open an [issue](https://github.com/your-username/algorithm-visualizer/issues).

## License

### How to Contribute

1. **Fork the Repository**
   - Click the "Fork" button on the GitHub repository page
   - Clone your fork locally: `git clone https://github.com/your-username/algorithm-visualizer.git`

2. **Create a Feature Branch**
   ```powershell
   git checkout -b feature/your-feature-name
   # or
   git checkout -b fix/bug-description
   ```

3. **� Make Your Changes**
   - Follow the existing code style and conventions
   - Add comprehensive unit tests for new functionality
   - Update documentation as needed

4. **Test Your Changes**
   ```powershell
   dotnet build
   dotnet test
   dotnet run --project AlgorithmVisualizer.UI
   ```

5. **Submit a Pull Request**
   - Commit your changes with clear, descriptive messages
   - Push to your feature branch: `git push origin feature/your-feature-name`
   - Open a Pull Request with a detailed description

### Contribution Guidelines

#### **Code Standards**
- Follow C# coding conventions and naming guidelines
- Use XML documentation for all public APIs
- Implement proper error handling and input validation
- Ensure thread-safe operations with cancellation support

#### **Algorithm Implementations**
- Must implement `ISortingAlgorithm` interface correctly
- Include comprehensive time/space complexity documentation
- Provide educational value with clear visualization steps
- Handle cancellation tokens appropriately

#### **Testing Requirements**
- Write unit tests for all new functionality
- Maintain minimum 80% code coverage
- Include edge case testing and error scenarios
- Performance tests for algorithm implementations

#### **Documentation**
- Update README.md for new features or changes
- Include code examples and usage instructions
- Maintain architectural documentation
- Add inline comments for complex logic

### Types of Contributions

- **New Algorithms**: Implement additional sorting or searching algorithms
- **UI Improvements**: Enhance user interface and user experience
- **Performance**: Optimize existing algorithms or rendering
- **Documentation**: Improve code documentation and guides
- **Bug Fixes**: Fix issues and improve stability
- **Testing**: Add tests and improve coverage

### Development Environment Setup

See the [Development](#️-development) section for detailed setup instructions.

### Questions or Ideas?

- Open an [Issue](https://github.com/your-username/algorithm-visualizer/issues) for questions or suggestions
- Contact maintainers for major feature discussions
- Star the repository if you find it useful!

## License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for complete details.

### License Summary
- **Commercial use** - Use in commercial projects
- **Modification** - Modify the source code  
- **Distribution** - Distribute original or modified versions
- **Private use** - Use for personal projects
- **Liability** - Authors not liable for damages
- **Warranty** - No warranty provided

## Acknowledgments

- **Educational Inspiration**: Built to enhance computer science education
- **Open Source Community**: Leveraging the power of collaborative development  
- **Microsoft .NET Team**: For the excellent .NET and WPF frameworks
- **Algorithm Research**: Based on established computer science principles
- **UI/UX Design**: Following modern Windows application design guidelines

### Technology Stack
- **.NET 8.0** - Modern, cross-platform framework
- **WPF** - Rich Windows desktop application framework  
- **C# 12.0** - Latest language features and performance improvements
- **Visual Studio** - Professional development environment

---

### Star this repository if you find it useful!

**Made with love for students, educators, and developers**

[Report Bug](https://github.com/your-username/algorithm-visualizer/issues) • [Request Feature](https://github.com/your-username/algorithm-visualizer/issues)