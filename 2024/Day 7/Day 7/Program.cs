namespace Day_7
{
    internal class Program
    {
        // Parse our file
        static List<(long, List<int>)> readFileContents(string path)
        {
            IEnumerable<string> contents = File.ReadLines(path);

            List<(long, List<int>)> calibrationEquations = new List<(long, List<int>)>();

            foreach (string line in contents)
            {
                // Split our string 
                string[] parts = line.Split(": ");

                // Set our values into the proper format
                long key = long.Parse(parts[0]);
                List<int> values = parts[1].Split(" ").Select(int.Parse).ToList();
                (long, List<int>) set = (key, values);

                calibrationEquations.Add(set);
            }

            return (calibrationEquations);
        }
        static void Main(string[] args)
        {

            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            List<(long, List<int>)> calibrationEquations = readFileContents(path);
                            
            Console.WriteLine($"Part 1: Calibration Result = {Part1.Run(calibrationEquations)}");

            Console.WriteLine($"Part 2: Calibration Result = {Part2.Run(calibrationEquations)}");
        }
    }
}