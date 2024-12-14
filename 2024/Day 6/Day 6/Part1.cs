namespace Day_6
{
    internal class Part1
    {
        public static (int, bool, (int, int)) NextPath(List<List<string>> map, (int, int) loc, (int, int) direction, string directionFacing, int total)
        {
            (int, int) newLoc = (loc.Item1 + direction.Item1, loc.Item2 + direction.Item2);

            List<string> obstacles = new List<string> { "#" };
            while ( Controller.IsValidMove(map, newLoc.Item1, newLoc.Item2) )
            {
                // Change guard direction on map, mark visited locations
                if (map[newLoc.Item1][newLoc.Item2] != "X")
                    total += 1;

                // Set guard position on map
                map = Visualizer.MarkLocation(map, loc, newLoc, directionFacing);

                // Update guard location
                loc = (newLoc.Item1, newLoc.Item2); // Move guard by 1 position

                // Set our next location to check
                newLoc.Item1 += direction.Item1;
                newLoc.Item2 += direction.Item2;
            }

            // If guard has left location, return exit as true, else false
            if ( Controller.IsOutOfBounds(map, newLoc.Item1, newLoc.Item2) )
            {
                map = Visualizer.MarkLocation(map, loc, newLoc, directionFacing);
                return (total, true, loc);
            }
            else return (total, false, loc);
        }
        public static (bool, int) Run(List<List<string>> map)
        {
            List<(int,int)> guardBuffer = new List<(int, int)>();
            int total = 1; // Start at 1, guard visiting current location
            (int, int) direction = (-1, 0); // Up
            string directionFacing = Visualizer.GetDirection(direction); // Set arrow direction. Does not affect functionality
            bool exit; // Indicates guard has left map

            // Find our initial starting point
            (int, int) guardLoc = Controller.FindGuard(map);

            while (true) // Run until guard leaves area
            {
                // Navigate in one direction until no longer possible
                (total, exit, guardLoc) = NextPath(map, guardLoc, direction, directionFacing, total);

                if (guardBuffer.Contains(guardLoc) && guardBuffer[guardBuffer.Count - 1] != guardLoc)
                {
                    return (true, total);
                }
                else
                    guardBuffer.Add(guardLoc);
                    

                // Turn the direction of the guard
                (direction, directionFacing) = Controller.GuardTurn(direction); // Changes guard direction

                if (exit ) break;
            }

            return (false, total);
        }
    }
}
