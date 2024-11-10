using System;

namespace ScriptureApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Initialize a Scripture instance
            Scripture scripture = new Scripture("Proverbs 3:5-6",
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways acknowledge Him, and He will make your paths straight.");

            Console.Clear();
            while (true)
            {
                // Display the current state of the scripture
                scripture.Display();
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input?.ToLower() == "quit")
                    break;

                // Attempt to hide a random word
                if (!scripture.HideRandomWord())
                {
                    Console.Clear();
                    Console.WriteLine("All words are hidden. Exiting program.");
                    break;
                }
            }
        }
    }
}
