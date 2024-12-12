namespace Day_4
{
    internal class Part2
    {
        public static string Reverse(string s)
        {
            // Reverse a string
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static List<(int, int)> FindStartingPoint(List<List<string>> data)
        {
            List<(int, int)> xCoordinates = new List<(int, int)>();
            // Find mid-point of our X (A)
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    if (data[i][j] == "A")
                    {
                        xCoordinates.Add((i, j));
                    }
                }
            }
            return xCoordinates;
        }
        public static int checkSurroundingValues(List<List<string>> data, (int x, int y) coordinate, string evaluator, string value)
        {
            int total = 0; 
            int valid = 0;

            // Check our four diagonals are within range
            if (
                (coordinate.x - 1) >= 0 && (coordinate.y - 1) >= 0 &&  // Top-left diagonal
                (coordinate.x - 1) >= 0 && (coordinate.y + 1) < data[0].Count &&  // Top-right diagonal
                (coordinate.x + 1) < data.Count && (coordinate.y - 1) >= 0 &&  // Bottom-left diagonal
                (coordinate.x + 1) < data.Count && (coordinate.y + 1) < data[0].Count     // Bottom-right diagonal
            )
            {
                // Find our diagonal strings
                string cross1 = data[coordinate.x - 1][coordinate.y - 1] + value + data[coordinate.x + 1][coordinate.y + 1];
                string cross2 = data[coordinate.x - 1][coordinate.y + 1] + value + data[coordinate.x + 1][coordinate.y - 1];

                string cross1Reverse = Reverse(cross1);
                string cross2Reverse = Reverse(cross2);

                // Determine if both crossed values spell "MAS"
                if (
                    (cross1Reverse == evaluator || cross1 == evaluator) &&
                    (cross2Reverse == evaluator || cross2 == evaluator)
                ) { total++; valid = 1; }
            }
                            
            return total;
        }
        public static int Run(List<List<string>> data)
        {
            int total = 0;

            // Find mid-point of our X (A)
            foreach ((int x, int y) in FindStartingPoint(data))
            {
                // Find coordinates for where M occurs next to X
                total += checkSurroundingValues(data, (x, y), "MAS", data[x][y]);
            }
            return total;
        }
    }
}
