namespace Day_9
{
    internal class Debugger
    {
        public static void VisualizeDisk(string[] disk)
        {
            // Used for debugging, print our current state of the disk
            foreach (string x in disk) Console.Write(x + " ");
            Console.WriteLine("");
        }
    }
}
