using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Journal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.AddEntry();
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        journal.SaveToFile();
                        break;
                    case "4":
                        journal.LoadFromFile();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    public class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private static readonly string[] prompts = new[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        public void AddEntry()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            Entry entry = new Entry(prompt, response);
            entries.Add(entry);
            Console.WriteLine("Entry added!");
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile()
        {
            Console.Write("Enter filename to save to: ");
            string filename = Console.ReadLine();

            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine("Journal saved!");
        }

        public void LoadFromFile()
        {
            Console.Write("Enter filename to load from: ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                entries = JsonConvert.DeserializeObject<List<Entry>>(json);
                Console.WriteLine("Journal loaded!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }

    public class Entry
    {
        public string Prompt { get; }
        public string Response { get; }
        public DateTime Date { get; }

        public Entry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Prompt}\nResponse: {Response}\n";
        }
    }
}
