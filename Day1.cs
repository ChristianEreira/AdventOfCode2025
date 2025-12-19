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
                var dist = int.Parse(line[1..]) * (line[0] == 'R' ? 1 : -1);
                currentNumber = (currentNumber + dist) % 100;
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
            var zeroCount = 0;

            var currentNumber = 50;

            inputLines.ForEach(line =>
            {
                var dist = int.Parse(line[1..]) * (line[0] == 'R' ? 1 : -1);

                zeroCount += (int)Math.Floor(Math.Abs((double)dist) / 100);
                if ((currentNumber + (dist % 100) < 1 || currentNumber + (dist % 100) > 99) && currentNumber != 0)
                {
                    zeroCount++;
                }

                currentNumber = (currentNumber + dist) % 100;
                if (currentNumber < 0)
                {
                    currentNumber = 100 + currentNumber;
                }
            });

            return zeroCount.ToString();
        }
    }
}
