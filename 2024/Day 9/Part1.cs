namespace Day_9
{
    internal class Part1
    {
        public string[] CompactDisk(string[] disk)
        {
            int endingDistance = 0;
            for (int i = 0; i < disk.Length; i++)
            {
                if (disk[i] == ".")
                {
                    string moveChar = disk[i];
                    Console.WriteLine(disk.Length - 1);
                    disk[i] = disk[((disk.Length - 1) - endingDistance)];//42
                    endingDistance++;
                    disk[((disk.Length - 1) - i)] = moveChar;
                }
            }

            return disk;
        }

        public long Run(string[] disk)
        {
            long checksum = 0;

            string[] compactedDisk = CompactDisk(disk);
            foreach (string x in compactedDisk) Console.Write(x + " ");
            Console.WriteLine("");

            return checksum;
        }
    }
}
