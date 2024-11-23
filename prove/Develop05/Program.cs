// Program.cs
using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a user
            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            User user = new User(userName);

            // Create some simple goals
            Goal goal1 = new Goal("Run a Marathon", "Run a marathon to earn points.", 1000);
            Goal goal2 = new Goal("Read Scriptures", "Read scriptures every day.", 100);
            Goal goal3 = new Goal("Attend the Temple", "Attend the temple 10 times.", 50);

            // Add goals to the user's goal list
            user.AddGoal(goal1);
            user.AddGoal(goal2);
            user.AddGoal(goal3);

            // Main menu for the program
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Complete a Goal");
                Console.WriteLine("3. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        user.DisplayGoals();
                        break;
                    case "2":
                        Console.WriteLine("Enter the name of the goal you want to complete:");
                        string goalName = Console.ReadLine();
                        user.CompleteGoal(goalName);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
