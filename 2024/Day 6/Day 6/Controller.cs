using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return x >= 0            // x upper bounds
                && x < map.Count     // x lower bounds
                && y >= 0            // y upper bounds
                && y < map[x].Count  // y lower bounds
                && map[x][y] != "#"; // Check if obstacle present
        }
    }
}
