namespace Day_6
{
    internal class Part1
    {
        public static (int, bool, (int, int)) NextPath(List<List<string>> map, (int, int) guardLoc, (int, int) direction, string directionFacing)
        {
            List<string> obstacles = new List<string> { "#" };
            int distanceTravelled = 0;
            while (
                (guardLoc.Item1 + direction.Item1) >= 0 && (guardLoc.Item1 + direction.Item1) < map.Count && // Check x bounds
                (guardLoc.Item2 + direction.Item2) >= 0 && (guardLoc.Item2 + direction.Item2) < map[guardLoc.Item1].Count && // Check y bounds
                !obstacles.Contains(map[guardLoc.Item1 + direction.Item1][guardLoc.Item2 + direction.Item2]) // Check if obstacle present
                )
            {
                // Change guard direction on map, mark visited locations
                if (map[guardLoc.Item1 + direction.Item1][guardLoc.Item2 + direction.Item2] != "X")
                {
                    distanceTravelled += 1;
                }
                map = Visualizer.MarkLocation(map, guardLoc, direction, directionFacing, obstacles);
                guardLoc = (guardLoc.Item1 + direction.Item1, guardLoc.Item2 + direction.Item2); // Move guard by 1 position
            }

            // If guard has left location, return exit as true, else false
            if (guardLoc.Item1 + direction.Item1 < 0 || guardLoc.Item1 + direction.Item1 >= map.Count || // Check x bounds
                guardLoc.Item2 + direction.Item2 < 0 || guardLoc.Item2 + direction.Item2 >= map[guardLoc.Item1].Count // Check y bounds
                )
            {
                map = Visualizer.MarkLocation(map, guardLoc, direction, directionFacing, obstacles);
                return (distanceTravelled, true, guardLoc);
            }
            else return (distanceTravelled, false, guardLoc);
        }
        public static int Run(List<List<string>> map)
        {
            int total = 1;
            (int, int) direction = (-1, 0);
            string directionFacing = Visualizer.GetDirection(direction);
            bool exit = false;
            int count = 0;

            // Find our initial starting point
            (int, int) guardLoc = Controller.FindGuard(map);

            while (true) // Run until guard leaves area
            {
                count += 1;
                // Navigate in one direction until no longer possible
                (int distance, exit, guardLoc) = NextPath(map, guardLoc, direction, directionFacing);

                // Turn the direction of the guard
                (direction, directionFacing) = Controller.GuardTurn(direction); // Changes guard direction

                total += distance;

                if (exit ) break;
            }

            return total;
        }
    }
}
