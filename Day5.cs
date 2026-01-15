namespace advent
{
    public class Day5 : Day
    {
        public Day5() : base("5") { }

        public override string Part1(List<string> inputLines)
        {
            int splitIndex = inputLines.FindIndex(line => line == "");
            long[][] ranges = [.. inputLines[..splitIndex].Select(line => line.Split('-').Select(long.Parse).ToArray())];
            long[] ingredients = [.. inputLines[(splitIndex + 1)..].Select(long.Parse)];

            int totalFreshIngredients = ingredients.Count(ingredient => ranges.Any(range => ingredient >= range[0] && ingredient <= range[1]));

            return totalFreshIngredients.ToString();
        }

        public override string Part2(List<string> inputLines)
        {
            int splitIndex = inputLines.FindIndex(line => line == "");
            long[][] ranges = [.. inputLines[..splitIndex].Select(line => line.Split('-').Select(long.Parse).ToArray())];

            ranges.Sort((a, b) => a[0].CompareTo(b[0]));

            List<long[]> newRanges = [[.. ranges[0]]];

            for (int i = 1; i < ranges.Length; i++)
            {
                long[] range = ranges[i];

                if (range[0] > newRanges[^1][1])
                {
                    newRanges.Add(range);
                }
                else
                {
                    newRanges[^1][1] = Math.Max(newRanges[^1][1], range[1]);
                }
            }

            return newRanges.Sum(range => range[1] - range[0] + 1).ToString();
        }
    }
}
