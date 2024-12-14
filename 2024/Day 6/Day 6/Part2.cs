using Microsoft.VisualBasic;

namespace Day_6
{
    internal class Part2
    {

        public static List<(int, int)> VisitedLocations(List<List<string>> guardRoute, List<List<string>> map)
        {
            (int, int) guardStart = Controller.FindGuard(map);
            List<(int, int)> visitedLocations = new List<(int, int)>();
            for (int i = 0; i < guardRoute.Count; i++)
            {
                for (int k = 0; k < guardRoute[i].Count; k++)
                {
                    if (guardRoute[i][k] == "X" && guardStart != (i, k))
                    {
                        visitedLocations.Add((i, k));
                    }
                }
            }
            

            return visitedLocations;
        }

        public static int Run(List<List<string>> map, List<List<string>> guardRoute)
        {
            int total = 0;
            List<(int, int)> visitedLocations = VisitedLocations(guardRoute, map);

            foreach (var location in visitedLocations)
            {
                List<List<string>> newMap = map.Select(row => new List<string>(row)).ToList();


                newMap[location.Item1][location.Item2] = "#";

                if (Part1.Run(newMap).Item1)
                {
                    total += 1;
                }
            }

            return total;
        }
    }
}
