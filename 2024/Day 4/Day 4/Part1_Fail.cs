namespace Day_4
{
    /// <summary>
    /// I think I overengineered this. This will find ALL instances, including words that switch directions mid-word...
    /// </summary>
    internal class Part1_Fail
    {
        public static List<(int, int)> FindStartingPoint(List<List<string>> data)
        {
            List<(int, int)> xCoordinates = new List<(int, int)> ();
            // Find coordinates for where X occurs
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    if (data[i][j] == "X")
                    {
                        xCoordinates.Add((i, j));
                    }
                }
            }
            return xCoordinates;
        }

        public static List<(int, int)> checkSurroundingValues(List<List<string>> data, (int x, int y) coordinate, string evaluator)
        {
            // Define the 8 possible directions (row offset, column offset)
            int[] dx = { -1, -1, -1,  0, 0,  1, 1, 1 };
            int[] dy = { -1,  0,  1, -1, 1, -1, 0, 1 };

            List<(int, int)> coordinates = new List<(int, int)> ();

            for (int k = 0; k < 8; k++)
            {
                int nx = coordinate.x + dx[k];
                int ny = coordinate.y + dy[k];

                // Check if the neighbor is within bounds
                if (nx >= 0 && nx < data.Count && ny >= 0 && ny < data[0].Count && data[nx][ny] == evaluator)
                {
                    coordinates.Add((nx, ny));
                }
            
            }

            return coordinates;
        }
        public static int Run(List<List<string>> data)
        {
            int total = 0;

            // Find coordinates for where X occurs
            foreach ((int x, int y) in FindStartingPoint(data))
            {
                // Find coordinates for where M occurs next to X
                foreach ((int mx, int my) in checkSurroundingValues(data, (x, y), "M"))
                { 
                    foreach ((int ax, int ay) in checkSurroundingValues(data, (mx, my), "A"))
                    { 
                        foreach ((int sx, int sy) in checkSurroundingValues(data, (ax, ay), "S"))
                        { 
                            total++;
                        }
                    }
                }
            }
            return total;
        }
    }
}
