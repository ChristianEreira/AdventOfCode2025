using advent;

void Menu()
{
    Day[] days = { new Day1() };

    Console.WriteLine("Options: ");
    foreach (Day day in days) {  Console.WriteLine(day); }
    Console.WriteLine("q - quit");
    Console.WriteLine();
    Console.Write("Which day's solution would you like to view? ");
    var input = Console.ReadLine();
    Console.WriteLine();

    if (input == "q") return;
    Array.Find(days, day => day.dayNumber == input)?.Execute();
    Console.WriteLine();

    Menu();
}

Menu();