namespace advent
{
    public class Day4 : Day
    {
        public Day4() : base("4") { }

        public override string Part1(List<string> inputLines)
        {
            int totalAccessibleRolls = 0;

            for (int i = 0; i < inputLines.Count; i++)
            {
                for (int j = 0; j < inputLines[i].Length; j++)
                {
                    if (IsRollAccessible(j, i, inputLines)) totalAccessibleRolls++;
                }
            }
            return totalAccessibleRolls.ToString();
        }

        public override string Part2(List<string> inputLines)
        {
            int totalRemoved = 0;
            int removedThisRun = -1;

            while (removedThisRun != 0)
            {
                removedThisRun = 0;
                for (int i = 0; i < inputLines.Count; i++)
                {
                    for (int j = 0; j < inputLines[i].Length; j++)
                    {
                        if (IsRollAccessible(j, i, inputLines))
                        {
                            removedThisRun++;
                            totalRemoved++;
                            inputLines[i] = string.Concat(inputLines[i][..j], ".", inputLines[i][(j + 1)..]);
                        }
                    }
                }
            }
            return totalRemoved.ToString();
        }

        private static bool IsRollAccessible(int x, int y, List<string> inputLines)
        {
            if (inputLines[y][x] != '@') return false;

            int numNeighbouringRolls = NEIGHBOURS.Count(direction =>
            {
                int xToCheck = x + direction[1];
                int yToCheck = y + direction[0];

                if (xToCheck < 0 || xToCheck >= inputLines[y].Length ||
                    yToCheck < 0 || yToCheck >= inputLines.Count)
                {
                    return false;
                }

                return inputLines[yToCheck][xToCheck] == '@';
            });

            return numNeighbouringRolls <= 3;
        }

        private static readonly int[][] NEIGHBOURS =
        [
           [-1, -1], [-1, 0], [-1, 1],
           [0, -1], [0, 1],
           [1, -1], [1, 0], [1, 1]
        ];
    }
}
