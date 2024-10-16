﻿using System;

namespace MTCG
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option (1-3): ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("You chose to Login.");

                        break;
                    case "2":
                        Console.WriteLine("You chose to Register.");

                        break;
                    case "3":
                        Console.WriteLine("Exiting program...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}