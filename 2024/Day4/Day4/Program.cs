namespace Day_4
{
    internal class Program
    {
        // Parse our file into two lists
        static List<List<string>> splitFileContents(string path)
        {
            IEnumerable<string> contents = File.ReadLines(path);
            List<List<string>> data = new List<List<string>>();

            foreach (string line in contents)
            {
                List<string> characters = new List<string>();
                foreach (char character in line)
                {
                    characters.Add(character.ToString());
                }
                data.Add(characters);
            }

            return data;
        }
        static void Main(string[] args)
        {
            // Define the path of our input file
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "input.txt");

            // Return the lists
            List<List<string>> data = splitFileContents(path);

            Console.WriteLine($"Part 1: Total Occurences = {Part1.Run(data)}"); // 2517
            Console.WriteLine($"Part 2: Total Occurences = {Part2.Run(data)}"); // 1960
        }
    }
}
