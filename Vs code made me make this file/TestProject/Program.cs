using System;

public class NumberPyramid
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please put in a number for a number pyramid.");
//sets the number we want to count up to
int number = Convert.ToInt32(Console.ReadLine());
//Intitializes the variable I to 0, used to track where we are in the loop
int i = 0;
//While loop that runs until I is equal to the number
while(i < number)
{
    //For loop that runs until J (the variable to track how many numbers per row) is equal to I
  for(int j = 0; j <= i; j++)
  {
    //adds 1 to I and prints it until J, the number of times we want to print it, is equal to I, the number we're at in the loop
    Console.Write(i + 1);
  }
  Console.WriteLine();
   
  i++; //adds 1 to I to move to the next number
}
    }
}
