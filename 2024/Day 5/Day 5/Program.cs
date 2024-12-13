namespace Day_5
{
    internal class Program
    {
        // Parse our file into two lists
        static (List<List<int>>, List<List<int>>) splitFileContents(string path)
        {
            IEnumerable<string> contents = File.ReadLines(path);

            List<List<int>> pageOrderingRules = new List<List<int>>();
            List<List<int>> pagesToProduce = new List<List<int>>();

            foreach (string line in contents)
            {
                if (string.IsNullOrWhiteSpace(line.Trim())) continue;
                else if (line.Contains("|")) pageOrderingRules.Add(line.Split("|").Select(int.Parse).ToList());
                else pagesToProduce.Add(line.Split(",").Select(int.Parse).ToList());
            }

            return (pageOrderingRules, pagesToProduce);
        }
        static void Main(string[] args)
        {
            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            (List<List<int>> pageOrderingRules, List<List<int>> pagesToProduce) = splitFileContents(path);

            Console.WriteLine($"Part 1: Total = {Part1.Run(pageOrderingRules, pagesToProduce)}");
            Console.WriteLine($"Part 2: Total = {Part2.Run(pageOrderingRules, pagesToProduce)}");
        }
    }
}
