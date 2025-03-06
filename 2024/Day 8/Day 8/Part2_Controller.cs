namespace Day_8
{
    internal class Part2_Controller
    {
        // Print both our original, and nodal maps
        public static void PrintMaps(List<List<string>> map, List<List<string>> antinodalMap)
        {
            for (int i = 0; i < map.Count; i++) // Print out our original and antinodal maps
                Console.WriteLine($"{string.Join(" ", map[i])}    |    {string.Join(" ", antinodalMap[i])}");
        }

        // Generate all nodes on the map, and their coordinates
        public static List<(string, int, int)> FindNodes(List<List<string>> map)
        {
            return map
                .SelectMany((row, i) => row // Flatten grid
                    .Select((cell, j) => (cell, i, j)) // Grab cell value and coordinates as a tuple
                    .Where(x => x.cell != ".")) // Only grab where cell != "."
                .ToList(); // Append tuples to a list
        }

        // Generate a list of nodal relations to find slope of antinodes
        public static List<((int, int), (int, int), (int, int))> FindNodalRelations(List<(string, int, int)> nodes)
        {
            List<((int, int), (int, int), (int, int))> nodalRelation = [];


            // Loop through each node
            for (int i = 0; i < nodes.Count; i++) {
                // Iterate until we have reached the last node
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    // Check if the nodes are the same type
                    if (nodes[i].Item1 == nodes[j].Item1)
                    {
                        int x1 = nodes[i].Item2;
                        int y1 = nodes[i].Item3;
                        int x2 = nodes[j].Item2;
                        int y2 = nodes[j].Item3;

                        // Calculate slope
                        int xSlope = x2 - x1;
                        int ySlope = y2 - y1;

                        // Append nodal relation to list
                        nodalRelation.Add((
                            (x1, y1),
                            (x2, y2),
                            (xSlope, ySlope)
                        ));
                    }
                }
            }

            return nodalRelation;
        }

        // Iterate in one direction until reaching the end of the map. Add antinodes
        public static List<List<string>> CheckDirection(List<List<string>> antinodalMap, int x1, int y1, int xSlope, int ySlope)
        {
            // Get the number of rows and columns in the grid
            int rows = antinodalMap.Count;
            int cols = antinodalMap[0].Count;

            // Start moving in the given direction
            while (x1 >= 0 && x1 < rows && y1 >= 0 && y1 < cols) // Check if the current coordinates are within bounds
            {
                // Mark the current position as an antinode (if not already)
                if (antinodalMap[x1][y1] != "#")
                {
                    antinodalMap[x1][y1] = "#";
                }

                // Move in the direction of the slope
                x1 += xSlope;
                y1 += ySlope;
            }

            return antinodalMap;
        }

        // Add base antinodes, invert slope for further generation
        public static List<List<string>> GenerateAntinodalMap(List<List<string>> antinodalMap, List<((int, int), (int, int), (int, int))> nodalRelations)
        {
            foreach (var relation in nodalRelations)
            {
                int x1 = relation.Item1.Item1;
                int y1 = relation.Item1.Item2;
                int xSlope = relation.Item3.Item1;
                int ySlope = relation.Item3.Item2;
                // Set initial nodes as antinodes, if they are not already set as one
                if (!(antinodalMap[x1][y1] == "#"))
                {
                    antinodalMap[x1][y1] = "#";
                    // antinodalMap[x1][y1] = "#";
                }

                // Add antinodes in each direction given the slope and starting point are known
                antinodalMap = CheckDirection(antinodalMap, x1, y1, -xSlope, -ySlope);
                antinodalMap = CheckDirection(antinodalMap, x1, y1, xSlope, ySlope);
            }

            return antinodalMap;
        }

        public static int GetTotalAntinodes(List<List<string>> antinodalMap)
        {
            int total = 0;

            for (int row = 0; row < antinodalMap.Count; row++)
            {
                for (int col = 0; col < antinodalMap[row].Count; col++)
                {
                    if (antinodalMap[row][col] == "#")
                    {
                        total++;
                    }
                }
            }

            return total;
        }
    }
}
