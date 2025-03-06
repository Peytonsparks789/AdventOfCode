namespace Day_8
{
    internal class Part2
    {
        public static int Run(List<List<string>> map)
        {
            // Create deep copy of the map for manipulation
            List<List<string>> antinodalMap = map.Select(row => new List<string>(row)).ToList();

            // Find all nodes, and their coordinates on the map
            List<(string, int, int)> nodes = Part2_Controller.FindNodes(map);
            //foreach (var node in nodes) Console.WriteLine(node);

            // Find each nodal relation and the slope of each pair
            List<((int, int), (int, int), (int, int))> nodalRelations = Part2_Controller.FindNodalRelations(nodes);
            //foreach (var relation in nodalRelations) Console.WriteLine(relation);

            // Generate a map containing all antinodes
            antinodalMap = Part2_Controller.GenerateAntinodalMap(antinodalMap, nodalRelations);

            // Visual representation of both maps for debugging
            Part2_Controller.PrintMaps(map, antinodalMap);

            // Find total antinodes that were identified
            return Part2_Controller.GetTotalAntinodes(antinodalMap);
        }
    }
}
