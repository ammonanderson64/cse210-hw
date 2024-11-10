using System;
using System.Collections.Generic;
using System.Linq;

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

    public class Scripture
    {
        private Reference Reference { get; set; }
        private List<Word> Words { get; set; }

        public Scripture(string referenceText, string text)
        {
            Reference = new Reference(referenceText);
            Words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public void Display()
        {
            Console.WriteLine(Reference.ToString());
            foreach (var word in Words)
            {
                if (!word.IsHidden)
                    Console.Write(word.Text + " ");
                else
                    Console.Write("**** ");
            }
            Console.WriteLine();
        }

        public bool HideRandomWord()
        {
            // Get the list of unhidden words
            var unhiddenWords = Words.Where(w => !w.IsHidden).ToList();
            if (unhiddenWords.Count == 0) return false;

            // Randomly select an unhidden word to hide
            Random rand = new Random();
            int index = rand.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            return true;
        }
    }

    public class Reference
    {
        public string Text { get; private set; }

        public Reference(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }
    }
}
