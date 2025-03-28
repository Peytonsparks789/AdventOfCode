namespace Day_9
{
    internal class Part1
    {
        
        private static int FindFileCount(string[] disk)
        {
            int fileCount = 0;

            // Find total files in disk
            foreach (string location in disk)
            {
                if (location != ".") fileCount++;
            }

            return fileCount;
        }
        private static string[] CompactDisk(string[] disk, int fileCount)
        {
            int diskSwapLoc = 0;

            // Iterate over every location in our file, up to the position of our fileCount
            for (int i = 0; i < fileCount; i++)
            {
                int swapPos = disk.Length - 1 - diskSwapLoc;

                // Swap values at current position until not empty space value
                if (disk[i] == "." && disk[swapPos] != ".")
                {
                    disk[i] = disk[swapPos];
                    disk[swapPos] = ".";
                    diskSwapLoc++;
                }
                else if (disk[i] == ".")
                {
                    i--;
                    diskSwapLoc++;
                }
                // Used for debugging
                //Debugger.VisualizeDisk(disk);
            }

            return disk;
        }
        private static long GenerateChecksum(string[] disk, int fileCount)
        {
            long checksum = 0;

            // Find our total files present on our disk
            for (int i = 0; i < fileCount; i++)
            {
                checksum += i * Convert.ToInt32(disk[i]);
            }

            return checksum;
        }
        public static long Run(string[] disk)
        {
            // Check how many files are present on our disk
            int fileCount = FindFileCount(disk);

            // compact our disk
            string[] compactedDisk = CompactDisk(disk, fileCount);

            // Generate the checksum
            long checksum = GenerateChecksum(compactedDisk, fileCount);

            return checksum;
        }
    }
}
