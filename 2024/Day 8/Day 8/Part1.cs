namespace Day_8
{
    internal class Part1
    {
        // Places antinodes on a map
        public static List<List<string>> GenerateAntinodes(List<List<(int, int)>> nodalDistances, List<List<string>> antinodalMap, List<List<string>> sourceMap)
        {
            foreach (var nodeSet in nodalDistances)
            {
                // Helper method to check and update the map
                bool CheckAndUpdate(int x, int y, int dx, int dy)
                {
                    if (Controller.CheckBounds(antinodalMap, x + dx, y + dy)
                        && antinodalMap[x + dx][y + dy] != "#" 
                        && sourceMap[x][y] != sourceMap[x + dx][y+dy]
                        )
                    {
                        antinodalMap[x + dx][y + dy] = "#";  // Update the map
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
            return antinodalMap;
        }
        public static int Run(List<List<string>> map)
        {
            // Create deep copy of our map for manipulation
            List<List<string>> antinodalMap = map.Select(row => new List<string>(row)).ToList();

            // Find all nodes, their adjacent nodes, and the distance between the two
            List<List<(int, int)>> nodalDistances = Controller.FindNodalDistance(map);

            // Generate a map containing all antinodes
            antinodalMap = GenerateAntinodes(nodalDistances, antinodalMap, map);

            // Visual representation of both maps for debugging
            Controller.PrintMaps(map, antinodalMap);

            // Find total antinodes that were identified
            return Controller.FindAntinodes(antinodalMap); 
        }
    }
}
