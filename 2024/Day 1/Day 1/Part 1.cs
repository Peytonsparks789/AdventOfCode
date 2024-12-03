namespace Day_1
{
    public class Part1
    {
        public static int Run(List<int> listA, List<int> listB)
        {
            listA.Sort();
            listB.Sort();

            // Add our differences
            int totalDistance = 0;
            int loc = 0;
            while (loc < listA.Count)
            {
                totalDistance += Math.Abs(listA[loc] - listB[loc]);
                loc++;
            }

            return totalDistance;
        }
    }
}
