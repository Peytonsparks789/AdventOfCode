namespace Day_5
{
    internal class Controller
    {
        /// <summary>
        /// This controller identifies valid and invalid page records
        /// </summary>
        public static bool CheckPage(List<List<int>> pageOrderingRules, List<int> page)
        {
            for (int i = 0; i < page.Count; i++)
            {
                if (!CheckRules(pageOrderingRules, page, i))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckRules(List<List<int>> pageOrderingRules, List<int> page, int pos)
        {
            foreach (var rule in pageOrderingRules)
            {
                if (rule[1] != page[pos]) continue;  // Skip if page[pos] does not match rule[1]

                for (int num = pos + 1; num < page.Count; num++)
                {
                    if (page[num] == page[pos]) { continue; }
                    if (rule[0] == page[num])
                    {
                        Console.WriteLine($"    Invalid line detected: {String.Join(", ", page)}");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
