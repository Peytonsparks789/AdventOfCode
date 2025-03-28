// Parse our file
using Day_8;

static List<List<string>> readFileContents(string path)
{
    IEnumerable<string> contents = File.ReadLines(path);

    List<List<string>> map = new List<List<string>>();

    foreach (string line in contents)
    {
        List<string> values = new List<string>();

        // Split our string
        foreach (var character in line)
            values.Add(character.ToString());

        map.Add(values);
    }

    return (map);
}
static void Main(string filename)
{

    // Define the path of our input file
    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, filename);

    List<List<string>> map = readFileContents(path);

    // foreach (var line in map) { Console.WriteLine(string.Join(", ", line)); }

    Console.WriteLine($"Part 1: Calibration Result = {Part1.Run(map)}");

    Console.WriteLine($"Part 2: Calibration Result = {Part2.Run(map)}");
}

string filename = "sample.txt";
Main(filename);