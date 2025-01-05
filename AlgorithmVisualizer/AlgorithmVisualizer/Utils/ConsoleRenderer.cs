namespace AlgorithmVisualizer.Utils
{
    public static class ConsoleRenderer
    {
        public static void RenderHeader(string algorithmName, TimeSpan elapsedTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Algorithm: {algorithmName}");
            Console.WriteLine($"Execution Time: {elapsedTime.TotalSeconds:F2} seconds");
            Console.WriteLine(new string('-', 50));

            Console.ResetColor();
        }

        public static void RenderArray(int[] array, int activeIndex, int adjustedIndex)
        {
            int maxHeight = 20;
            int maxValue = array.Length;

            Console.SetCursorPosition(0, 4);
            for (int row = maxHeight; row > 0; row--)
            {
                for (int col = 0; col < array.Length; col++)
                {
                    int barHeight = array[col] * maxHeight / maxValue;

                    if (barHeight >= row)
                    {
                        if (col == activeIndex)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else if (col == adjustedIndex)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
