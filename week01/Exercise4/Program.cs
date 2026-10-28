using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       List<int> numbers = new List<int>();
       int userNumber= -1;

       Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

       while(userNumber != 0)
        {
            Console.Write("Enter a number: ");
            userNumber =int.Parse(Console.ReadLine());

            if(userNumber!=0)
            {
                numbers.Add (userNumber);
            }
        }   
        int sum=0;
        
        foreach (int number in numbers)
        {
            sum += number; 
        }

        
        Console.WriteLine($"The sum is: {sum}");

        double average= (double)sum / numbers.Count;
        Console.WriteLine($"The Average is {average}");

        int max= numbers [0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max=number;
            }

        }
        Console.WriteLine($"The largest number is: {max}"); 

        // Stretch Challenge 1: Find the smallest positive number
            int smallestPositive = -1;
            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    if (smallestPositive == -1 || num < smallestPositive)
                    {
                        smallestPositive = num;
                    }
                }
            }

            if (smallestPositive != -1)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers were entered.");
            }

            // Stretch Challenge 2: Sort the list and display it
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
       
       

    }  
}      
     
        