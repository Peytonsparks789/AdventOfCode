namespace Day_2
{
    internal class Program
    {
        // Parse our file into two lists
        static List<List<int>> splitFileContents(string path)
        {
            IEnumerable<string> contents = File.ReadLines(path);
            List<List<int>> data = new List<List<int>>();

            foreach (string line in contents)
            {
                List<int> values = new List<int>(Array.ConvertAll(line.Split(' '), int.Parse));
                data.Add(values);
            }

            return data;
        }
        static void Main(string[] args)
        {
            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            // Return the lists
            List<List<int>> data = splitFileContents(path);

            Console.WriteLine($"Part 1: {Part1.Run(data)} safe levels");
            Console.WriteLine($"Part 2: {Part2.Run(data)} safe levels when utilizing the Problem Dampener");
        }
    }
}
