using System;

public class Tempuratureadvisor
{
    //lets you input command-line arguments to the program
    public static void Tempurature(string[] args)
    {
        Console.WriteLine("Good morning, what is the tempurature? Please use Celsius!");
        float tempurature = Convert.ToSingle(Console.ReadLine());
        //Console.readline() reads the next line of characters from the standard input stream and returns it as a string
        //the convert.to functions turns the input string into a thing of the type you want
        if (tempurature < 0)
        {
            Console.WriteLine("It is cold, make sure to bring a sweater!");
        }
        else if (tempurature > 30)
        {
            Console.WriteLine("It is hot! Wear sunscreen and stay hydrated. Avoid staying in the sun for too long!");
        }
        else
        {
            Console.WriteLine("It is good weather today, awesome! have a nice day!");
        }
    }
}