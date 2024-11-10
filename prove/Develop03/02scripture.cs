using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureApp
{
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
}
