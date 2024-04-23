using System;

class Program
{
  static void Main()
  {
    // Generate a random number between 1 and 10
    Random random = new Random();
    int randomNumber = random.Next(1, 11);
    int attempts = 0;

    Console.WriteLine("Welcome to the Quirky Number Guessing Game!");

    while (true)
    {
      Console.Write("Guess a number between 1 and 10: ");
      int guess = int.Parse(Console.ReadLine());
      attempts++;

      // Check if the guess is equal to the random number
      if (guess == randomNumber)
      {
        Console.WriteLine($"Congratulations! You guessed the number {randomNumber} in {attempts} attempts.");
        break;
      }
      // Check if the guess is lower than the random number
      else if (guess < randomNumber)
      {
        Console.WriteLine("Too low! Try again.");
      }
      // The guess must be higher than the random number
      else
      {
        Console.WriteLine("Too high! Try again.");
      }
    }
  }
}