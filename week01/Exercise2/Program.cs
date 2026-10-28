using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is your grade? ");
        string grade=Console.ReadLine();
        int number = int.Parse(grade);
        string letter="";
        

        if(number >= 90)
        {
           letter= "A";
        }

        else if(number >= 80)
        {
            letter="B";
        }

        else if(number >= 70)
        {
            letter="C";
        }

        else if(number >= 60)
        {
            letter="D";
        }

        else 
        {
            letter="F";
        }
        //Completed the stretch challenge//

        string sign="";
        int lastDigit = number % 10;

    
        if (lastDigit>=7)
        {
            sign = "+";
        }
        else if (lastDigit<3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }

        if (letter == "F")
        {
            sign = ""; 
        }


        Console.WriteLine($"Your Grade is {letter}{sign}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations You Passed The Course");
        }

        else 
        {
            Console.WriteLine("Try Harder Next time");
        }
    }
}