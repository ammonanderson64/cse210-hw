// User.cs
using System;
using System.Collections.Generic;

namespace EternalQuest
{
    public class User
    {
        public string UserName { get; set; }
        public int TotalScore { get; set; }
        public List<Goal> Goals { get; set; }

        public User(string userName)
        {
            UserName = userName;
            TotalScore = 0;
            Goals = new List<Goal>();
        }

        // Add a new goal to the user's list
        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        // Record completion of a goal and update score
        public void CompleteGoal(string goalName)
        {
            foreach (var goal in Goals)
            {
                if (goal.Name == goalName && !goal.IsComplete)
                {
                    goal.CompleteGoal();
                    TotalScore += goal.Points;
                    Console.WriteLine($"Total Score: {TotalScore} points");
                    return;
                }
            }
            Console.WriteLine("Goal not found or already completed.");
        }

        // Display all the goals of the user
        public void DisplayGoals()
        {
            Console.WriteLine($"Goals for {UserName}:");
            foreach (var goal in Goals)
            {
                goal.DisplayGoalInfo();
            }
        }
    }
}
