namespace Day4
{
    internal class Part1
    {
        public static List<(int, int)> FindStartingPoint(List<List<string>> data)
        {
            List<(int, int)> xCoordinates = new List<(int, int)>();
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

        public static int checkSurroundingValues(List<List<string>> data, (int x, int y) coordinate, string evaluator, string value)
        {
            int total = 0;

            // Define the 8 possible directions to search
            (int, int) north     = (-1,  0);
            (int, int) northeast = (-1,  1);
            (int, int) east      = ( 0,  1);
            (int, int) southeast = ( 1,  1);
            (int, int) south     = ( 1,  0);
            (int, int) southwest = ( 1, -1);
            (int, int) west      = ( 0, -1);
            (int, int) northwest = (-1, -1);

            // List of directions
            List<(int, int)> directions = new List<(int, int)>() { north, northeast, east, southeast, south, southwest, west, northwest };


                // Loop through each direction
            foreach ((int dx, int dy) in directions)
            {
                int newX = coordinate.x;
                int newY = coordinate.y;
                value = data[newX][newY];
                for (int i = 0; i < 3; i++)
                {
                    newX += dx;
                    newY += dy;
                    if (newX >= 0 && newX < data.Count && newY >= 0 && newY < data[0].Count)
                    {
                        value = value + data[newX][newY];
                    }
                    //Console.WriteLine($"{value}, {newX}, {newY}");
                    if (value == evaluator) { total++; }
                }
            }
            return total;
        }
        public static int Run(List<List<string>> data)
        {
            int total = 0;

            // Find coordinates for where X occurs
            foreach ((int x, int y) in FindStartingPoint(data))
            {
                // Find coordinates for where M occurs next to X
                total += checkSurroundingValues(data, (x, y), "XMAS", data[x][y]);
            }
            return total;
        }
    }
}
