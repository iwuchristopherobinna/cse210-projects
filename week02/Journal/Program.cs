using System;

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
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string userEntry = Console.ReadLine();

                        Entry newEntry = new Entry();
                        newEntry._date = DateTime.Now.ToShortDateString();
                        newEntry._promptText = prompt;
                        newEntry._entryText = userEntry;

                        theJournal.AddEntry(newEntry);
                        break;

                    case 2:
                        Console.WriteLine("\n--- Journal Entries ---");
                        theJournal.DisplayAll();
                        break;

                    case 3:
                        Console.Write("\nEnter filename to save (e.g., journal.txt): ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case 4:
                        Console.Write("\nEnter filename to load (e.g., journal.txt): ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case 5:
                        Console.WriteLine("\nGoodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please pick between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number.");
            }
        }
    }
}