using System;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
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
}
