using System;

// Exceeding Requirements :
// I used  clean object-oriented programming by organizing my code into separate files (Entry.cs, 
// Journal.cs, PromptGenerator.cs, Program.cs) matching the design patterns shown in the lessons. 

// I also added smart input checking so the program won't break if someone accidentally 
// types a letter or wrong symbol instead of a menu number.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write ");
            Console.WriteLine("2. Display ");
            Console.WriteLine("3. Save ");
            Console.WriteLine("4. Load ");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"{prompt}");
                        Console.Write("> ");
                        string userEntry = Console.ReadLine();
                        
                        Entry newEntry = new Entry();
                        newEntry._date = DateTime.Now.ToShortDateString();
                        newEntry._promptText = prompt;
                        newEntry._entryText = userEntry;
                        
                        theJournal.AddEntry(newEntry);
                        break;

                    case 2:
                        Console.WriteLine(" Journal Entries ");
                        theJournal.DisplayAll();
                        break;

                    case 3:
                        Console.Write("Enter filename to save : ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case 4:
                        Console.Write("Enter filename to load : ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please pick between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}