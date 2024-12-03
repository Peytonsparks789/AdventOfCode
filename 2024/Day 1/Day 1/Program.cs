namespace Day_1
{
    internal class Program
    {
        // Parse our file into two lists
        static (List<int>, List<int>) splitFileContents(IEnumerable<string> contents)
        {
            List<int> listA = new List<int>();
            List<int> listB = new List<int>();

            foreach (string line in contents)
            {
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Add values to the respective lists
                listA.Add(int.Parse(parts[0]));
                listB.Add(int.Parse(parts[1]));
            }

            // Return both lists as a tuple
            return (listA, listB);
        }
        static void Main(string[] args)
        {
            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            // Return the two lists
            var (listA, listB) = splitFileContents(File.ReadLines(path));

            Console.WriteLine($"Part 1: {Part1.Run(listA, listB)}");
            Console.WriteLine($"Part 2: {Part2.Run(listA, listB)}");
        }
    }
}
