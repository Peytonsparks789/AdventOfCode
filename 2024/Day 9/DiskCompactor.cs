namespace Day_9
{
    internal class DiskCompactor
    {
        public static List<int> Part1CompactDisk(List<int> disk)
        {
            int diskSwapLoc = 0;
            int fileCount = disk.Count(location => location != -1);

            // Iterate over every position on our disk, up to the total amount of files on our disk
            for (int i = 0; i < fileCount; i++)
            {
                // Swap disk values if current position is empty
                if (disk[i] == -1)
                {
                    while (disk[disk.Count - 1 - diskSwapLoc] == -1 && diskSwapLoc < disk.Count - 1)
                    {
                        diskSwapLoc++;
                    }
                    disk[i] = disk[disk.Count - 1 - diskSwapLoc];
                    disk[disk.Count - 1 - diskSwapLoc] = -1;
                    diskSwapLoc++;
                }
            }

            // Remove our empty values and return file array
            return disk.Where(x => x != -1).ToList();
        }
        public static List<int> Part2CompactDisk(List<int> disk)
        {
            return disk;
        }
    }
}
