using System;

class Program
{
  static void Main()
  {
    // Prompt the user to enter their three favorite foods
    Console.WriteLine("Enter your three favorite foods:");

    // Create an array to store the food items
    string[] favoriteFoods = new string[3];

    // Read the user's input and store it in the array
    for (int i = 0; i < favoriteFoods.Length; i++)
    {
      Console.Write($"Food {i + 1}: ");
      favoriteFoods[i] = Console.ReadLine();
    }

    // Display each food item with a message
    Console.WriteLine("Here are your favorite foods:");
    foreach (string food in favoriteFoods)
    {
      Console.WriteLine("I absolutely enjoy " + food + "!");
    }
  }
}