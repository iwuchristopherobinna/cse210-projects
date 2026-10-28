using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Stretch Challenge 2: Loop to play the entire game again if user says "yes"
        while (playAgain.ToLower() == "yes")
        {
            
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); 

            int guess = -1;
            int guessCount = 0; 

            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                
                if (int.TryParse(input, out guess))
                {
                    guessCount++;

                    
                    if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            // Stretch Challenge 1: Inform the user how many guesses it took
            Console.WriteLine($"It took you {guessCount} guesses to find the magic number.");

            // Stretch Challenge 2: Ask if they want to play again
            Console.Write("Would you like to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}