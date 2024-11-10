using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for shared functionality across activities
    abstract class Activity
    {
        protected int duration;
        protected string description;

        // Method to start the activity
        public void StartActivity()
        {
            ShowStartMessage();
            GetDuration();
            ShowPrepareMessage();
            Pause(3); // Give time to prepare before starting
        }

        // Show the start message
        private void ShowStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting: {GetType().Name}");
            Console.WriteLine(description);
        }

        // Get the duration for the activity
        private void GetDuration()
        {
            Console.WriteLine("\nPlease enter the duration of the activity in seconds: ");
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        // Prepare the user for the activity
        private void ShowPrepareMessage()
        {
            Console.WriteLine("\nPrepare to begin...");
            Pause(2);
        }

        // Common method to pause for a given number of seconds and show animation
        protected void Pause(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Clear();
                Console.WriteLine("Preparing...");
                Console.WriteLine("...");
                Thread.Sleep(1000);
            }
        }

        // Abstract method for finishing the activity
        public abstract void EndActivity();
    }

    // Breathing Activity class
    class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        // Perform breathing activity
        public void PerformBreathing()
        {
            for (int i = 0; i < duration / 10; i++) // Assuming 10 seconds per breath cycle
            {
                Console.Clear();
                Console.WriteLine("Breathe in...");
                Pause(5); // Wait for 5 seconds
                Console.Clear();
                Console.WriteLine("Breathe out...");
                Pause(5); // Wait for 5 seconds
            }
        }

        public override void EndActivity()
        {
            Console.Clear();
            Console.WriteLine($"Good job! You completed the Breathing Activity for {duration} seconds.");
            Pause(3);
        }
    }

    // Reflection Activity class
    class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        public void PerformReflection()
        {
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.Clear();
            Console.WriteLine(prompt);
            Pause(5);

            for (int i = 0; i < duration / 6; i++) // Assuming 6 seconds per question
            {
                string question = questions[rand.Next(questions.Count)];
                Console.Clear();
                Console.WriteLine(question);
                Pause(5);
            }
        }

        public override void EndActivity()
        {
            Console.Clear();
            Console.WriteLine($"Good job! You completed the Reflection Activity for {duration} seconds.");
            Pause(3);
        }
    }

    // Listing Activity class
    class ListingActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
        {
            description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public void PerformListing()
        {
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.Clear();
            Console.WriteLine(prompt);
            Pause(3);

            Console.WriteLine("\nStart listing your thoughts now. Press Enter after each entry.");
            List<string> items = new List<string>();

            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("Item: ");
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    items.Add(item);
                }
            }

            Console.Clear();
            Console.WriteLine($"You listed {items.Count} items.");
            Console.WriteLine("Here they are:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public override void EndActivity()
        {
            Console.Clear();
            Console.WriteLine($"Good job! You completed the Listing Activity for {duration} seconds.");
            Pause(3);
        }
    }

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
