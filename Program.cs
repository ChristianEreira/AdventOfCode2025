using advent;

void Menu()
{
    Day[] days = { new Day1(), new Day2(), new Day3(), new Day4(), new Day5() };

    Console.WriteLine("Options: ");
    foreach (Day day in days) { Console.WriteLine(day); }
    Console.WriteLine("q - quit");
    Console.WriteLine();
    Console.Write("Which day's solution would you like to view? ");
    string? input = Console.ReadLine();
    Console.WriteLine();

    if (input == "q") return;
    Array.Find(days, day => day.dayNumber == input)?.Execute();
    Console.WriteLine();

    Menu();
}

Menu();