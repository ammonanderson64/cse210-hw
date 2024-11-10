using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int choice = GetUserChoice();
                Activity activity = null;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        activity.StartActivity();
                        ((BreathingActivity)activity).PerformBreathing();
                        activity.EndActivity();
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        activity.StartActivity();
                        ((ReflectionActivity)activity).PerformReflection();
                        activity.EndActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        activity.StartActivity();
                        ((ListingActivity)activity).PerformListing();
                        activity.EndActivity();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Show the main menu
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
        }

        // Get the user's choice from the menu
        static int GetUserChoice()
        {
            Console.Write("\nEnter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Invalid choice. Please enter a number between 1 and 4: ");
            }
            return choice;
        }
    }
}
