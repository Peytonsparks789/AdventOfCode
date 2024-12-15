namespace Day_8
{
    internal class Part1
    {
        // Finds adjacent nodes and their distances to a given node
        public static List<List<(int,int)>> FindNodes(List<List<string>> map, string nodeType, (int, int) currentNode)
        { 
            List<List<(int, int)>> nodes = new List<List<(int, int)>> ();

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
                        nodes.Add (node);
                    }
                }
            }

            return nodes;
        }
        // Finds nodes, then determines coordinates of adjacent nodes
        public static List<List<(int, int)>> FindNodalDistance(List<List<string>> map)
        {
            List<List<(int, int)>> nodePoints = new List<List<(int, int)>> ();
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

        // Places antinodes on a map
        public static (int, List<List<string>>) GenerateAntinodes(List<List<(int, int)>> nodalDistances, List<List<string>> antinodalMap)
        {
            ///
            ///
            /// 
            /// 
            ///
            int total = 0;
            foreach (var nodeSet in nodalDistances)
            {
                Console.WriteLine($"{nodeSet[0]}, {nodeSet[1]}, {nodeSet[2]}");

                // Helper method to check and update the map
                bool CheckAndUpdate(int x, int y, int dx, int dy)
                {
                    if (Controller.CheckBounds(antinodalMap, x + dx, y + dy)
                        && antinodalMap[x + dx][y + dy] != "#" 
                        && antinodalMap[x][y] != antinodalMap[x + dx][y+dy]
                        )
                    {
                        antinodalMap[x + dx][y + dy] = "#";  // Update the map
                        total++;  // Increment the total
                        return true;  // Indicate that an update happened
                    }
                    return false;  // No update occurred
                }

                // First node, lower check
                if (CheckAndUpdate(nodeSet[0].Item1, nodeSet[0].Item2, nodeSet[2].Item1, nodeSet[2].Item2)) continue;

                // First node, upper check
                if (CheckAndUpdate(nodeSet[0].Item1, nodeSet[0].Item2, -nodeSet[2].Item1, -nodeSet[2].Item2)) continue;

                // Second node, lower check
                if (CheckAndUpdate(nodeSet[1].Item1, nodeSet[1].Item2, nodeSet[2].Item1, nodeSet[2].Item2)) continue;

                // Second node, upper check
                if (CheckAndUpdate(nodeSet[1].Item1, nodeSet[1].Item2, -nodeSet[2].Item1, -nodeSet[2].Item2)) continue;
            }

            return (total, antinodalMap);
        }
        public static int Run(List<List<string>> map)
        {
            int total = 0;
            // Create deep copy of our map for manipulation
            List<List<string>> antinodalMap = map.Select(row => new List<string>(row)).ToList();

            // Visual representation of both maps for debugging
            Controller.PrintMaps(map, antinodalMap);

            // Find all nodes, their adjacent nodes, and the distance between the two
            List<List<(int, int)>> nodalDistances = FindNodalDistance(map);

            foreach (var values in nodalDistances)
            {
                Console.WriteLine(string.Join(", ", values));
            }

            // Generate a map containing all antinodes
            (total, antinodalMap) = GenerateAntinodes(nodalDistances, antinodalMap);

            // Visual representation of both maps for debugging
            Controller.PrintMaps(map, antinodalMap);

            // Find total antinodes that were identified
            return total; 
        }
    }
}
