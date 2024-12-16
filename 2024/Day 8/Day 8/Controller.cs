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
            return map.Sum(row => row.Count(col => col == "#"));
        }
        public static bool CheckBounds(List<List<string>> map, int x, int y)
        {
            return x >= 0            // x upper bound
                && x < map.Count     // x lower bound
                && y >= 0            // y upper bound
                && y < map[x].Count; // y lower bound
        }
        // Finds adjacent nodes and their distances to a given node
        public static List<List<(int, int)>> FindNodes(List<List<string>> map, string nodeType, (int, int) currentNode)
        {
            List<List<(int, int)>> nodes = new List<List<(int, int)>>();

            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; map[i].Count > j; j++)
                {
                    if (map[i][j] == nodeType && (i, j) != currentNode)
                    {
                        List<(int, int)> node = new List<(int, int)>
                        {
                            currentNode,
                            (i, j),
                            (currentNode.Item1 - i, currentNode.Item2 - j)
                        };
                        nodes.Add(node);
                    }
                }
            }
            return nodes;
        }
        // Finds nodes, then determines coordinates of adjacent nodes
        public static List<List<(int, int)>> FindNodalDistance(List<List<string>> map)
        {
            List<List<(int, int)>> nodePoints = new List<List<(int, int)>>();
            for (int i = 0; i < map.Count; i++)  // Iterate over rows
            {
                for (int j = 0; j < map[i].Count; j++)  // Iterate over positions within each row
                {
                    if (map[i][j] != ".")
                    {
                        nodePoints.AddRange(FindNodes(map, map[i][j], (i, j)));
                    }
                }
            }
            return nodePoints;
        }
    }
}
