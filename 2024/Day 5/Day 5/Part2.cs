namespace Day_5
{
    internal class Part2
    {
        public static (bool, List<int>) SortPages(List<List<int>> pageOrderingRules, List<int> page)
        {
            bool toTotal = false;
            while (!Controller.CheckPage(pageOrderingRules, page))
            {
                toTotal = true;
                for (int i = page.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < pageOrderingRules.Count; j++)
                    {
                        if (pageOrderingRules[j][0] == page[i])
                        {
                            int swapValue = page.IndexOf(pageOrderingRules[j][1]);
                            if (swapValue >= 0 && swapValue < i)
                            {
                                int temp = page[i];
                                page[i] = page[swapValue];
                                page[swapValue] = temp;
                            }
                        }
                    }
                }
            }

            return (toTotal, page);
        }
        public static int Run(List<List<int>> pageOrderingRules, List<List<int>> pagesToProduce)
        {
            int total = 0;
            List<List<int>> sortedList = new List<List<int>>();

            foreach (List<int> page in pagesToProduce)
            {
                bool toAdd = false;
                (toAdd, List<int> newPage) = SortPages(pageOrderingRules, page);
                if (toAdd)
                {
                    sortedList.Add(newPage);
                    total += newPage[page.Count / 2];
                }
            }

            return total;
        }
    }
}
