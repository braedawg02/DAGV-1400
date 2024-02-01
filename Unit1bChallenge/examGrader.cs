using System;

public class examGrader
{
    //lets you input command-line arguments to the program
    public void getGrade(string[] args)
    {
        
        Console.WriteLine("What is your grade?");
        int grade = Convert.ToInt32(Console.ReadLine());
        if (grade < 50)
        {
            Console.WriteLine("Womp womp, you failed. Better luck next time.");
        }
        else if (grade > 50 && grade < 60)
        {
            Console.WriteLine("You got a D. You might want to study more.");
        }
        else if (grade > 60 && grade < 70)
        {
            Console.WriteLine(" you got a C. C's get degrees so don't let it get you down!");
        }
        else if (grade > 70 && grade < 80)
        {
            Console.WriteLine("you did alright, you got a B.");
        }
        else if (grade > 80 && grade < 90)
        {
            Console.WriteLine("Nice, you got an A.");
        }
        else if (grade > 90 && grade < 100)
        {
            Console.WriteLine("Congrats! you got an A+.");
        }
        else
        {
            Console.WriteLine("Congrats! You got an A++.");
        }
    }
}