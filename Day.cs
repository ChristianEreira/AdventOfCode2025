namespace advent
{
    public abstract class Day
    {
        public string dayNumber;
        public Day(string dayNumber)
        {
            this.dayNumber = dayNumber;
        }

        public abstract string Part1(List<string> inputLines);

        public abstract string Part2(List<string> inputLines);

        public void Execute()
        {
            var inputLines = GetInputList(dayNumber);

            Console.WriteLine($"Part1: {Part1(inputLines)}");
            Console.WriteLine($"Part2: {Part2(inputLines)}");
        }

        public static List<string> GetInputList(string dayNumber)
        {
            return File.ReadAllLines(@$".\inputs\{dayNumber}.txt").ToList();
        }

        override public string ToString()
        {
            return $"{dayNumber} - day {dayNumber}";
        }
    }
}
