namespace Day_8
{
    internal class Controller
    {
        public static void PrintMaps(List<List<string>> map, List<List<string>> antinodalMap)
        {
            for (int i = 0; i < map.Count; i++) // Print out our original and antinodal maps
                Console.WriteLine($"{string.Join(" ", map[i])}    |    {string.Join(" ", antinodalMap[i])}");
        }
        public static int FindAntinodes(List<List<string>> map)
        {
            return map.Sum(row => row.Count(col => col == "X"));
        }
        public static bool CheckBounds(List<List<string>> map, int x, int y)
        {
            return x >= 0            // x upper bound
                && x < map.Count     // x lower bound
                && y >= 0            // y upper bound
                && y < map[x].Count; // y lower bound
        }

    }
}
