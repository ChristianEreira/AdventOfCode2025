namespace advent
{
    public class Day2 : Day
    {
        public Day2() : base("2") { }

        public override string Part1(List<string> inputLines)
        {
            var ranges = inputLines[0].Split(',');

            long invalidIdSum = 0;

            ranges.ToList().ForEach(range =>
            {
                var limits = range.Split('-');

                for (long intId = long.Parse(limits[0]); intId <= long.Parse(limits[1]); intId++)
                {
                    var id = intId.ToString();
                    if (id.Length % 2 == 0 && id[..(id.Length / 2)] == id[(id.Length / 2)..]) invalidIdSum += intId;
                }
            });

            return invalidIdSum.ToString();
        }

        public override string Part2(List<string> inputLines)
        {
            var ranges = inputLines[0].Split(',');

            long invalidIdSum = 0;

            ranges.ToList().ForEach(range =>
            {
                var limits = range.Split('-');

                for (long intId = long.Parse(limits[0]); intId <= long.Parse(limits[1]); intId++)
                {
                    var id = intId.ToString();
                    
                    for (int numChars = 1; numChars <= id.Length / 2; numChars++)
                    {
                        if (id.Length % numChars == 0)
                        {
                            if (string.Concat((new Array[id.Length / numChars]).Select((_) => id[..numChars])) == id)
                            {
                                invalidIdSum += intId;
                                break;
                            }
                        }
                    }
                }
            });

            return invalidIdSum.ToString();
        }
    }
}
