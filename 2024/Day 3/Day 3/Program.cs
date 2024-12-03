using System.IO;

namespace Day_3
{
    internal class Program
    {
        // Parse our file into two lists
        static List<string> splitFileContents(string path)
        {
            IEnumerable<string> contents = File.ReadLines(path);
            List<string> data = new List<string>();

            foreach (string line in contents)
            {
                data.Add(line);
            }

            return data;
        }
        static void Main(string[] args)
        {
            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            // Return the lists
            List<string> data = splitFileContents(path);

            Console.WriteLine($"Part 1: Total = {Part1.Run(data)}");
            Console.WriteLine($"Part 2: Total = {Part2.Run(data)}");
        }
    }
}
