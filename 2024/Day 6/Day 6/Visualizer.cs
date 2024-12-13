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

        public static List<List<string>> MarkLocation(List<List<string>> map, (int, int) loc, (int, int) newLoc, string directionFacing)
        {
            if ( Controller.IsValidMove(map, newLoc.Item1, newLoc.Item2) )
                map[newLoc.Item1][newLoc.Item2] = directionFacing; // Move guard is still within bounds
            map[loc.Item1][loc.Item2] = "X"; // Mark visited locations

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
