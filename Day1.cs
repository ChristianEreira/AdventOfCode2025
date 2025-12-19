namespace advent
{
    public class Day1 : Day
    {
        public Day1() : base("1") { }

        public override string Part1(List<string> inputLines)
        {
            var zeroCount = 0;

            var currentNumber = 50;

            inputLines.ForEach(line =>
            {
                var dir = line[0];
                currentNumber = (currentNumber + (int.Parse(line[1..]) * (dir == 'R' ? 1 : -1))) % 100;
                if (currentNumber < 0)
                {
                    currentNumber = 100 + currentNumber;
                }
                if (currentNumber == 0)
                {
                    zeroCount++;
                }
            });

            return zeroCount.ToString();
        }

        public override string Part2(List<string> inputLines)
        {
            return "Part2 answer here";
        }
    }
}
