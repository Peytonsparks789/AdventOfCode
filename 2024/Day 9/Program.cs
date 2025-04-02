using Day_9;
using System.Diagnostics;
static void VisualizeDisk(List<int> disk)
{
    // Used for debugging, print our current state of the disk
    Console.WriteLine(string.Join(" ", disk));
}
static List<int> ReadDisk(string path)
{ // Return our raw input from our file
    return File.ReadAllText(path)
               .Where(char.IsDigit)
               .Select(value => int.Parse(value.ToString()))
               .ToList();
}
static List<int> ParseDisk(List<int> disk)
{ // Parse our raw input as a map of files and empty spaces
    int loc = 0;
    var parsedDisk = new List<int>();

    for (int i = 0; i < disk.Count; i++)
    {
        bool file = (i % 2 == 0);
        parsedDisk.AddRange(Enumerable.Repeat(file ? loc : -1, disk[i]));
        if (file) loc++;
    }
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
static void Main(string filename)
{
    Stopwatch fileParsingTimer = Stopwatch.StartNew();
    var disk = new List<int>();

    disk = ReadDisk(filename);
    VisualizeDisk(disk);

    disk = ParseDisk(disk);
    VisualizeDisk(disk);
    fileParsingTimer.Stop();

    // Part 1
    Stopwatch part1Timer = Stopwatch.StartNew();
    var part1Disk = DiskCompactor.Part1CompactDisk(disk);
    VisualizeDisk(part1Disk);
    Console.WriteLine($"Part 1: Checksum = {GenerateChecksum(part1Disk)}");
    part1Timer.Stop();
    Console.WriteLine($"Part 1 Timer: {part1Timer.ElapsedMilliseconds + fileParsingTimer.ElapsedMilliseconds}ms");

    // Part 2
    Stopwatch part2Timer = Stopwatch.StartNew();
    var part2Disk = DiskCompactor.Part2CompactDisk(disk);
    VisualizeDisk(part2Disk);
    Console.WriteLine($"Part 2: Checksum = {GenerateChecksum(part2Disk)}");
    part1Timer.Stop();
    Console.WriteLine($"Part 2 Timer: {part2Timer.ElapsedMilliseconds + fileParsingTimer.ElapsedMilliseconds}ms");
}

Main("C:/Users/Sparksp/Documents/GitHub/AdventOfCode/2024/Day 9/sample.txt");