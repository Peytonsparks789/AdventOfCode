using System.Text.RegularExpressions;

namespace Day_3
{
    internal class Part1
    {
        public static List<List<int>> ParseValues(List<string> matchedValues)
        {
            List<List<int>> pairs = new List<List<int>>();

            for (int i = 0; i < matchedValues.Count; i++)
            {
                string value = matchedValues[i].Replace("mul(", "").Replace(")", "");
                pairs.Add(value.Split(",").Select(int.Parse).ToList());
            }
            return pairs;
        }
        public static int Run(List<string> data)
        {
            int total = 0;

            foreach (var line in data)
            {
                // Regex pattern to match "mul(*,*)", "do()", and "don't()"
                string pattern = @"mul\(\-?\d+,\-?\d+\)";

                // Find all matches
                MatchCollection matches = Regex.Matches(line, pattern);

                // Extract matched values
                List<string> matchedValues = new List<string>();
                foreach (Match match in matches)
                {
                    matchedValues.Add(match.Value);
                }

                // Parse over our pairs to return the integers
                List<List<int>> x = ParseValues(matchedValues);

                // Multiply our totals together for each pair
                foreach (List<int> value in x)
                {
                    total += value[0] * value[1];
                }
            }

            return total;
        }
    }
}
