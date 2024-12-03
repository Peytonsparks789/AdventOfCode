using System.Text.RegularExpressions;

namespace Day_3
{
    internal class Part2
    {
        public static (List<List<int>>, int) ParseValues(List<string> matchedValues, int lastInstruction)
        {
            List<List<int>> pairs = new List<List<int>>();
            // Remove disabled values
            for (int i = 0; i < matchedValues.Count; i++)
            {
                switch (lastInstruction)
                {
                    case 0: // Remove values until told to stop. Flip lastInstruction
                        while ( i < matchedValues.Count && matchedValues[i] != "do()") // Remove values until we reach a do()
                        { matchedValues.RemoveAt(i); }
                        if ( i < matchedValues.Count ) 
                        {
                            matchedValues.RemoveAt(i); // Remove the do() that lives at this position after iteration
                            i--;
                            lastInstruction = 1;
                        }
                        break;
                    case 1: // Retain values until told to stop. Flip lastInstruction
                        if (matchedValues[i] == "don't()")
                        {
                            matchedValues.RemoveAt(i);
                            i--;
                            lastInstruction = 0;
                            break;
                        }
                        else if (matchedValues[i] == "do()")
                        {
                            matchedValues.RemoveAt(i);
                        }
                        break;
                }
            }
            for (int i = 0; i < matchedValues.Count; i++)
            {
                string value = matchedValues[i].Replace("mul(","").Replace(")", "");
                pairs.Add(value.Split(",").Select(int.Parse).ToList());
            }
            return (pairs, lastInstruction);
        }
        public static int Run(List<string> data)
        {
            int total = 0;
            int lastInstruction = 1; // 0 = don't(); 1 = do()

            foreach (var line in data)
            {
                // Regex pattern to match "mul(*,*)", "do()", and "don't()"
                string pattern = @"mul\(\-?\d+,\-?\d+\)|do\(\)|don't\(\)";

                // Find all matches
                MatchCollection matches = Regex.Matches(line, pattern);

                // Extract matched values
                List<string> matchedValues = new List<string>();
                foreach (Match match in matches)
                {
                    matchedValues.Add(match.Value);
                }

                List<List<int>> x = new List<List<int>>();
                // Parse over our pairs to return the integers
                (x, lastInstruction) = ParseValues(matchedValues, lastInstruction);

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
