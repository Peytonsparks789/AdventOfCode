namespace Day_6
{
    internal class Controller
    {/// <summary>
    /// Houses all code used by both parts of the problem that lead to the solution
    /// </summary>
        public static (int, int) FindGuard(List<List<string>> map)
        {
            for (int i = 0; i < map.Count; i++)
            {
                int guardLoc = map[i].IndexOf("^");
                if (guardLoc >= 0)
                {
                    return (i, guardLoc);
                }
            }
            return (-1, -1); // We should not return this ever
        }
        public static ((int, int), string) GuardTurn((int, int) direction)
        {
            direction = (direction.Item2, -direction.Item1);

            // Change guard direction when printing map
            string directionFacing = Visualizer.GetDirection(direction);

            return (direction, directionFacing);
        }
        public static bool IsValidMove(List<List<string>> map, int x, int y)
        {
            return x >= 0            // x upper bound
                && x < map.Count     // x lower bound
                && y >= 0            // y upper bound
                && y < map[x].Count  // y lower bound
                && map[x][y] != "#"; // Check if obstacle present
        }
        public static bool IsOutOfBounds(List<List<string>> map, int x, int y)
        {
            // Returns whether or not the guard has left the map boundaries
            return x < 0              // x upper bound
                || x >= map.Count     // x lower bound
                || y < 0              // y upper bound
                || y >= map[x].Count; // y lower bound
        }
    }
}
