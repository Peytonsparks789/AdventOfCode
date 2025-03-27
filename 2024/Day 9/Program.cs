using Day_9;

static string[] ParseDisk(string[] disk)
{
    List<string> list = new List<string>();
    int loc = 0;

    // Iterate over every item in our disk
    for (int i = 0; i < disk.Length; i++) 
    {
        // Determine whether current disk location is an empty space or file
        bool file = (i % 2 == 0);

        // Iterate 
        for (int j = 0; j < Convert.ToInt32(disk[i]); j++)
        {
            if (file)
            {
                list.Add(loc.ToString());
            }
            else list.Add(".");
        }

        if (file)
        {
            if (loc == 9) loc = 0;
            else loc++;
        }
    }

    // Append list to a new array
    string[] parsedDisk = list.ToArray();

    return parsedDisk;
}

static string[] ReadDisk(string filename)
{
    // Define the path of our input file
    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, filename);

    // Read our file to a string
    string contents = File.ReadAllText(path);

    // Append string elements to an array
    string[] disk = contents.Select(c => c.ToString()).ToArray();

    return disk;
}

static void Main(string filename)
{
    string[] disk = ReadDisk(filename);

    string[] parsedDisk = ParseDisk(disk);

    // Print our string
    foreach (string x in disk) Console.Write(x + " ");
    Console.WriteLine("");
    foreach (string x in parsedDisk) Console.Write(x + " ");
    Console.WriteLine("");

    // Part 1
    var part1 = new Part1();
    Console.WriteLine($"\nPart 1: Checksum = {part1.Run(disk)}");

    // Console.WriteLine($"Part 2: Calibration Result = {Part2.Run(map)}");
}

Main("sample.txt");