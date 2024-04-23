using System;

namespace MyApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      // Strings are used for phrases or characters that aren't quantitative. this outputs "Sawed-off Shotgun"
      string gun = "Sawed-off Shotgun";
      Console.WriteLine(gun); 
     
      //Int is used for whole numbers, without decimals. Can be negative or positive. this will output 2
      int ammo = 3;      
      Console.WriteLine(ammo);
     
      //a double stores "floating point numbers" with decimals. Called a double since it has twice the amount of bits compared to a normal float.
      //this will output 1.95
      double damage = 1.95;
      Console.WriteLine(damage);
      
      //Char stores a single character. This will output "S"
      char grade = 'S';
      Console.WriteLine(grade);

      //Bool can store either true or false. in this case, it will output True.
      bool isCool = true;
      Console.WriteLine(isCool);
      
      //the multiply operator * multiplies numbers, can be used with double and int. in this case, it will output 97.5
      double totalDamage = damage*50;
      Console.WriteLine(totalDamage);
      
      //the add operator adds two values, in this case (2 strings) it will append the strings together. can be used with all data types.
      //this will output "You are wielding a Sawed-off Shotgun."
      string whatGun = "You are wielding a " + gun + ".";
      Console.WriteLine(whatGun);
     
      //the subtract operator subtracts values. cannot be used with strings/chars/Bool. In this case it will output 1.
      int shotsLeft = ammo - 1;
      Console.WriteLine(shotsLeft);
      
      //Guess what the Division operator does? Suprise! it divides! can't be used with strings/chars/Bool. This will output 2564
      int gunCost = (int)(5000 / damage);
      Console.WriteLine(gunCost);
      
      //Modulus returns the division remainder. Doesn't work with the usual 3 types that don't always work. this will return 0.05.
      double gunRemainder = 2 % damage;
      Console.WriteLine(gunRemainder);
      
      //Increment increases the value of a variable by 1, while Decrement Decreases the value by one. this affects the actual variable itself,
      //so keep it in mind as you reference it. this will return "2 shot(s) left","1 shot(s) left" and "reloaded 1 bullet, you now have 2 shots."
      ammo--;
      Console.WriteLine(ammo + " shot(s) left");
      ammo--;
      Console.WriteLine(ammo + " shot(s) left");
      ammo++;
      Console.WriteLine("reloaded 1 bullet, you now have " + ammo + " shots.");
    
     }
  }
}
