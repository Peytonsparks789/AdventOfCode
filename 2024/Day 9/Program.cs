using Day_9;
using System.Diagnostics;
static void VisualizeDisk(List<int> disk)
{ // Used for debugging, print our current state of the disk
    Console.WriteLine(string.Join(" ", disk));
}
static List<int> FileParser(string path)
{
    // Read the file content and parse digits into a list of integers
    var disk = File.ReadAllText(path)
                   .Where(char.IsDigit)
                   .Select(value => int.Parse(value.ToString()))
                   .ToList();
    VisualizeDisk(disk);

    // Initialize location counter and parsed disk list
    int loc = 0;
    var parsedDisk = new List<int>();

    // Iterate through the disk list to create a map of files and empty spaces
    for (int i = 0; i < disk.Count; i++)
    {
        // Determine if the current index represents a file or empty space
        bool file = (i % 2 == 0);

        // Add the appropriate number of locations or empty spaces to the parsed disk list
        parsedDisk.AddRange(Enumerable.Repeat(file ? loc : -1, disk[i]));

        // Increment location counter if the current index represents a file
        if (file) loc++;
    }
    VisualizeDisk(parsedDisk);

    return parsedDisk;
}
    static long GenerateChecksum(List<int> disk)
{
    long checksum = 0;

    // Find our total files present on our disk
    for (int i = 0; i < disk.Count; i++)
    {
        checksum += i * disk[i];
    }
    return checksum;
}
static void Main(string path)
{
    var disk = new List<int>();

    // Part 1
    Stopwatch part1Timer = Stopwatch.StartNew();
    Console.WriteLine("Part 1:");
    disk = FileParser(path);
    disk = DiskCompactor.Part1CompactDisk(disk);
    VisualizeDisk(disk);
    part1Timer.Stop();
    Console.WriteLine($"Part 1: Checksum = {GenerateChecksum(disk)}");
    Console.WriteLine($"Part 1 Timer: {part1Timer.ElapsedMilliseconds}ms");

    // Part 2
    Stopwatch part2Timer = Stopwatch.StartNew();
    Console.WriteLine("\n \nPart 2:");
    disk = FileParser(path);
    disk = DiskCompactor.Part2CompactDisk(disk);
    VisualizeDisk(disk);
    Console.WriteLine($"Part 2: Checksum = {GenerateChecksum(disk)}");
    part1Timer.Stop();
    Console.WriteLine($"Part 2 Timer: {part2Timer.ElapsedMilliseconds}ms");
}

Main("C:/Users/Sparksp/Documents/GitHub/AdventOfCode/2024/Day 9/sample.txt");