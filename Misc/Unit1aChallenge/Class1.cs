namespace Unit1aChallenge;

public class Class1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer:");
        int myInteger = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a float:");
        float myFloat = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine("Enter a boolean (true or false):");
        bool myBoolean = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("Enter a string:");
        string myString = Console.ReadLine();

        Console.WriteLine("Integer: " + myInteger);
        Console.WriteLine("Float: " + myFloat);
        Console.WriteLine("Boolean: " + myBoolean);
        Console.WriteLine("String: " + myString);

        // Arithmetic operations
        int additionResult = myInteger + 5;
        float subtractionResult = myFloat - 1.5f;
        int multiplicationResult = myInteger * 2;
        float divisionResult = myFloat / 2;

        Console.WriteLine("Addition Result: " + additionResult);
        Console.WriteLine("Subtraction Result: " + subtractionResult);
        Console.WriteLine("Multiplication Result: " + multiplicationResult);
        Console.WriteLine("Division Result: " + divisionResult);
    }
}

