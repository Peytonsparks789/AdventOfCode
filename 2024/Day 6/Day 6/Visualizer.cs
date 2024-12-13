namespace Day_6
{
    internal class Visualizer
    {
        /// <summary>
        /// Used for debugging the problem through command line
        /// </summary>
        public static void PrintMap(List<List<string>> map)
        {
            Console.WriteLine("==== Guard Map ====");
            foreach (List<string> row in map)
            {
                Console.WriteLine(String.Join(" ", row));
            }
            Console.WriteLine("===================");
        }

        public static List<List<string>> MarkLocation(List<List<string>> map, (int, int) guardLoc, (int, int) direction, string directionFacing, List<string> obstacles)
        {
            if ( // As long as within bounds, move guard
                guardLoc.Item1 + direction.Item1 >= 0 && guardLoc.Item1 + direction.Item1 < map.Count && // Check x bounds
                guardLoc.Item2 + direction.Item2 >= 0 && guardLoc.Item2 + direction.Item2 < map[guardLoc.Item1 + direction.Item1].Count && // Check y bounds
                !obstacles.Contains(map[guardLoc.Item1 + direction.Item1][guardLoc.Item2 + direction.Item2]) // Check if it's not an obstacle
                )
            {
                map[guardLoc.Item1 + direction.Item1][guardLoc.Item2 + direction.Item2] = directionFacing;
                map[guardLoc.Item1][guardLoc.Item2] = "X";
            }
            else map[guardLoc.Item1][guardLoc.Item2] = "X"; // Mark visited locations

            return map;
        }
        public static string GetDirection((int, int) direction)
        {
            switch (direction)
            {
                case (1, 0): // Down
                    return "v";
                case (0, -1): // Left
                    return "<";
                case (0, 1): // Right
                    return ">";
                default: // Up
                    return "^";
            }
        }
    }
}
