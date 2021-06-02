using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter age:");
            string age = Console.ReadLine();
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Your age is: " +age);
            Console.WriteLine("Your name is: " + name);
        }
    }
}
