namespace Day_2
{
    internal class Part2
    {
        private static int Validator(List<int> list)
        {
            int initialDirection = list[0] > list[1] ? 1 : 0; // 1 if true, 0 if false"
            int safe = 0; // 1 if report safe, 0 if unsafe

            for (int pos = 0; pos < list.Count; pos++)
                {
                    if (pos + 1 < list.Count)
                    {
                        if (
                            (list[pos] > list[pos + 1] && Math.Abs(list[pos] - list[pos + 1]) <= 3 && initialDirection == 1) |
                            (list[pos] < list[pos + 1] && Math.Abs(list[pos] - list[pos + 1]) <= 3 && initialDirection == 0)
                            )
                        { safe = 1; }
                        else { safe = 0; break; }
                    }
                }

            return safe;
        }

        public static int Run(List<List<int>> data)
        {
            int safetyReport = 0; // Total safe reports
    
            foreach (var list in data)
            {
                int reportAddition = Validator(list) == 1 ? 1 : 0; // 1 if it is valid, 0 if not valid
                
                if (reportAddition == 0)
                {
                    for (int levelPos = 0; levelPos < list.Count; levelPos++)
                    {
                        int removedValue = list[levelPos]; // Store the value to be removed

                        list.RemoveAt(levelPos); // Temporarily remove the element

                        if (Validator(list) == 1)
                        {
                            reportAddition = 1;
                            break;
                        }
                        else { list.Insert(levelPos, removedValue); } // Add back our element
                    }
                }
                safetyReport += reportAddition; // Add our value
            }

            return safetyReport;
        }
    }
}
