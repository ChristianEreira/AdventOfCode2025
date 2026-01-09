namespace advent
{
    public class Day3 : Day
    {
        public Day3() : base("3") { }

        public override string Part1(List<string> inputLines)
        {
            int totalJoltage = inputLines.Sum(bank =>
            {
                char[] batteries = bank.ToCharArray();
                char firstDigit = batteries[..^1].OrderByDescending(c => c).ToArray()[0];

                char[] batteriesAfterFirst = batteries[(bank.IndexOf(firstDigit) + 1)..];
                char secondDigit = batteriesAfterFirst.OrderByDescending(c => c).ToArray()[0];

                return int.Parse($"{firstDigit}{secondDigit}");
            });

            return totalJoltage.ToString();
        }

        public override string Part2(List<string> inputLines)
        {


            long totalJoltage = inputLines.Sum(bank =>
            {
                int totalBatteries = 12;
                List<char> selectedBatteries = new();

                char[] batteries = bank.ToCharArray();

                selectedBatteries.Add(batteries[..^(totalBatteries - 1)].OrderByDescending(c => c).ToArray()[0]);

                for (int remainingBatteries = totalBatteries - 1; remainingBatteries > 0; remainingBatteries--)
                {
                    batteries = batteries[(batteries.IndexOf(selectedBatteries[^1]) + 1)..];
                    selectedBatteries.Add(batteries[..^(remainingBatteries - 1)].OrderByDescending(c => c).ToArray()[0]);
                }

                return long.Parse(string.Concat(selectedBatteries));
            });

            return totalJoltage.ToString();
        }
    }
}
