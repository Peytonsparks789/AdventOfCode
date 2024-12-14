namespace Day_6
{
    internal class Program
    {
        // Parse our file into two lists
        static List<List<string>> readFileContents(string path)
        {
            IEnumerable<string> contents = File.ReadLines(path);

            List<List<string>> map = new List<List<string>>();

            foreach (string line in contents)
            {
                List<string> row = new List<string>();
                for(int i = 0; i < line.Length; i++)
                {
                    row.Add(line[i].ToString());
                }

                map.Add(row);
            }

            return (map);
        }
        static void Main(string[] args)
        {

            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            List<List<string>> map = readFileContents(path);

            List<List<string>> mapPart1 = map.Select(row => new List<string>(row)).ToList();
            Console.WriteLine($"Part 1: Total Distinct Locations = {Part1.Run(mapPart1).Item2}");

            List<List<string>> mapPart2 = map.Select(row => new List<string>(row)).ToList();
            Console.WriteLine($"Part 2: Total Extra Obstacle Locations = {Part2.Run(mapPart2, mapPart1)}");
        }
    }
}