namespace Day_5
{
    internal class Part1
    {
        public static int Run(List<List<int>> pageOrderingRules, List<List<int>> pagesToProduce)
        {
            int total = 0;
            List<List<int>> invalidPages = new List<List<int>>();

            foreach (var page in pagesToProduce)
            {
                if (Controller.CheckPage(pageOrderingRules, page))
                {
                    Console.WriteLine($"    Valid line detected: {String.Join(", ", page)} \n        Adding {page[(page.Count / 2)]}");
                    total += page[(page.Count / 2)];
                }
            }
            return total;
        }
    }
}
