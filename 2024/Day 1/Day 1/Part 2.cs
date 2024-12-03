namespace Day_1
{
    public class Part2
    {
        public static int Run(List<int> listA, List<int> listB)
        {
            int similarityScore = 0;

            foreach (int valueA in listA)
            {
                int valueOccurence = 0;
                foreach (int valueB in listB)
                {
                    if (valueA == valueB)
                    {
                        valueOccurence += 1;
                    }
                }
                similarityScore += valueA * valueOccurence;
            }

            return similarityScore;
        }
    }
}