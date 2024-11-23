// Goal.cs
using System;

namespace EternalQuest
{
    public class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get; set; }

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        // Method to mark the goal as complete
        public void CompleteGoal()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
            }
            else
            {
                Console.WriteLine($"Goal '{Name}' is already completed.");
            }
        }

        // Method to display goal info
        public void DisplayGoalInfo()
        {
            string status = IsComplete ? "Completed" : "Not completed";
            Console.WriteLine($"{Name}: {Description} - {status} (Points: {Points})");
        }
    }
}
