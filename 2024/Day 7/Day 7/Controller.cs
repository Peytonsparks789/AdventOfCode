namespace Day_7
{
    internal class Controller
    {
        public static long ApplyOperator(long left, long right, string op)
        {
            // Return the result of our operation
            return op switch
            {
                "*"  => left * right,                 // Multiplication
                "||" => long.Parse($"{left}{right}"), // Concatenation
                _    => left + right                  // Addition
            };
        }
        public static List<string[]> GenerateOperatorCombinations(List<string> operators, int length)
        {
            List<string[]> results = new List<string[]>();

            // Recursive method to generate all combinations of operators
            void Generate(string[] current, int position)
            {
                // If we have reached the desired length, add the current combination to results
                if (position == length)
                {
                    results.Add((string[])current.Clone());
                    return;
                }

                // Loop through each operator and generate further combinations
                foreach (var op in operators)
                {
                    current[position] = op;          // Set the operator at the current position
                    Generate(current, position + 1); // Recurse to the next position
                }
            }

            // Start generating combinations with an empty array of the specified length
            Generate(new string[length], 0);

            return results;
        }
    }
}
