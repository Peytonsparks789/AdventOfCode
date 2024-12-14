namespace Day_7
{
    internal class Part1
    {
        public static long Run(List<(long, List<int>)> calibrationEquations)
        {
            long total = 0;
            List<string> possibleOperators = new List<string> { "+", "*" };

            // Loop through each equation
            foreach (var set in calibrationEquations)
            {
                // Set our initial starting value for the current equation
                int equationLength = set.Item2.Count;

                // Generate all combinations of operators
                foreach (var combination in Controller.GenerateOperatorCombinations(possibleOperators, equationLength - 1))
                {
                    // Set our initial value
                    long currentValue = set.Item2[0];

                    // Combine two numbers using the given operator
                    for (int i = 0; i < equationLength - 1; i++)
                        currentValue = Controller.ApplyOperator(currentValue, set.Item2[i + 1], combination[i]);

                    // Determine if ending value is a valid equation solution
                    if (set.Item1 == currentValue)
                    {
                        total += set.Item1;
                        break;
                    }
                }
            }

            return total;
        }
    }
}