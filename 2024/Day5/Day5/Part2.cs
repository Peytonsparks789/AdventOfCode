namespace Day_5
{
    internal class Part2
    {
        public static List<int> SortPages(List<List<int>> pageOrderingRules, List<int> page)
        {
            List<int> sortedList = new List<int>();

            // NEED TO SORT HERE, THEN RETURN SORTED LIST
            sortedList = page;

            return sortedList;
        }
        public static int Run(List<List<int>> pageOrderingRules, List<List<int>> pagesToProduce)
        {
            int total = 0;
            List<List<int>> sortedList = new List<List<int>>();

            foreach (List<int> page in pagesToProduce)
            {
                if (!Controller.CheckPage(pageOrderingRules, page))
                {
                   total += SortPages(pageOrderingRules, page)[(page.Count / 2)];
                }
            }

            // foreach (var rule in invalidPages) { Console.WriteLine(String.Join(", ", rule)); }

            return total;
        }
    }
}
