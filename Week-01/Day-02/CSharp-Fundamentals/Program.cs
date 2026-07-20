// See https://aka.ms/new-console-template for more information
using System;
class Program
{   /*
    static void Main()
    {
        DemonstrateCopyBehavior();
    }

     static void DemonstrateCopyBehavior()
    {

    Console.WriteLine("=== Value Type ===");

       int originalNumber = 10;
        int CopiedNumber = originalNumber;
        
        Console.WriteLine("Before modification:");
        Console.WriteLine($"{originalNumber} : {originalNumber}");
        Console.WriteLine($"{CopiedNumber} : {CopiedNumber}");
             CopiedNumber = 20;
        Console.WriteLine("After modification:");
        Console.WriteLine($"{originalNumber} : {originalNumber}");
        Console.WriteLine($"{CopiedNumber} : {CopiedNumber}");
             Console.WriteLine();
        Console.WriteLine("=== Reference Type Copy ===");
          int[] originalArray = {1 , 2 , 3};
          int[] CopiedArray = originalArray;
          
          Console.WriteLine("Before modification:");
        Console.WriteLine($"originalArray first elements : {originalArray[0]}");
         Console.WriteLine($"CopiedArray first elements : {CopiedArray[0]}");
                   
                   CopiedArray[0] = 100;
         
         Console.WriteLine("Afyer modification:");
        Console.WriteLine($"originalArray first elements : {originalArray[0]}");
         Console.WriteLine($"CopiedArray first elements : {CopiedArray[0]}");
    
        
    }
    */

    static void Main()
    {
        Console.Write("Enter your name: ");
        string? name = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("No valid name was entered.");
        }
        else
        {
            Console.WriteLine($"Hello, {name}");
        }
    }
}
