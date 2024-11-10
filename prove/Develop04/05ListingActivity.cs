using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
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
}
