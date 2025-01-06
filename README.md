
# Algorithm Visualizer

An interactive **sorting algorithm visualizer** built with C#, now featuring a **modern WPF-based GUI**. This application provides an intuitive way to learn and understand how various sorting algorithms work through real-time visualizations.

---

## Features

- **Algorithms Supported**:
  - Bubble Sort
  - Quick Sort
  - Merge Sort
  - Selection Sort
  - Heap Sort
  - Insertion Sort
- **Dynamic Visualization**:
  - Bars represent the array elements.
  - Colors:
    - **Gray**: Default state.
    - **Red**: Comparing elements.
    - **GreenYellow**: Selected or currently active element.
- **Interactive Controls**:
  - Start and stop buttons for controlling the execution.
  - Algorithm selection via a dropdown menu.
- **Customizable Execution Speed**:
  - Modify the delay globally to adjust visualization speed.

---

## Technology Stack

- **Frontend**: Windows Presentation Foundation (WPF)
- **Backend**: C# (.NET)
- **Other Tools**:
  - LINQ for array manipulations.
  - Multithreading with `Task` and `CancellationToken` for smooth execution and interrupt handling.

---

## Installation and Usage

1. Clone this repository:
   ```bash
   git clone https://github.com/luangrezende/algorithm-visualizer.git
   ```
2. Open the project in Visual Studio.
3. Build the solution to restore dependencies.
4. Run the project.

---

## How It Works

1. **Launch the application**: A WPF window with a dropdown for algorithm selection and Start/Stop buttons will appear.
2. **Choose an algorithm**: Select your desired sorting algorithm from the dropdown menu.
3. **Click "Start"**: Watch the algorithm dynamically sort a randomized array of integers.
4. **Stop or restart**: Use the Stop button to interrupt and reset the visualization.

---

## Preview

### Main Interface

![Algorithm Visualizer GUI](![alt text](image.png))

- **VisualizerCanvas**: Displays the array as bars.
- **Controls**: Dropdown to select algorithms, and buttons to start or stop execution.

---

## Future Improvements

- Add more sorting algorithms (e.g., Radix Sort, Shell Sort).
- Implement array size customization.
- Provide detailed step-by-step textual explanations for each algorithm.

---

## Contributions

Contributions are welcome! To contribute:
1. Fork this repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature
   ```
3. Commit your changes and push the branch.
4. Open a pull request.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---
