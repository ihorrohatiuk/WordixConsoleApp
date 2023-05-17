using System;
using System.IO; //for file
using System.Threading; //for delay


namespace WordixConsoleApp
{ 
    internal class Program
    {
        private static Set NewSet;
        static Set[] Sets = Array.Empty<Set>();

        static void Main()
        {
            Console.Clear();
        
            StartScreen();
        }

        static void StartScreen()
        {
            Console.Clear();

            Console.WriteLine("Hello, my name is Wordix! I help people to remember words easyest =)\n");
            Console.WriteLine("[N] - to create a new word-list.");
            Console.WriteLine("[R] - to copy a new word-list from the file.");
            Console.WriteLine("[T] - to make a test.");
            Console.WriteLine("[I] - to see Set-Info.");
            Console.WriteLine("[D] - to delete all sets.");
            Console.WriteLine("[Q] - to quit.");

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.N:
                    CreateSet();
                    break;
                case ConsoleKey.R:
                    CreateFromFile();
                    break;
                case ConsoleKey.T:
                    TestList();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    return;
                case ConsoleKey.I:
                    SetInfo();
                    return;
                case ConsoleKey.D:
                    DeleteSets();
                    return;
                default:
                    StartScreen();
                    break;
            }
        }

        //Creating a new SET
        static void CreateSet()
        {
            Console.Clear();

            //Addind a NAME
            Console.Write("Write a set name: ");
            string? name = Console.ReadLine();
            NewSet = new Set(name);

            //Adding new set into array
            Array.Resize(ref Sets, Sets.Length + 1);
            Sets[^1] = NewSet;

            while(true) 
            {
                //[*]Info
                Console.WriteLine("\n[!] Press \'+\' to add a question-answer block or \'S\' to exit");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.OemPlus:

                        //Addind a question
                        Console.WriteLine("\n1) Add a question");
                        string? GetQuestion = Console.ReadLine();

                        Array.Resize(ref NewSet.Questions, NewSet.Questions.Length + 1);
                        NewSet.Questions[^1] = GetQuestion;

                        //Addind a answer
                        Console.WriteLine("\n2) Add an answer");
                        string? GetAnswer = Console.ReadLine();

                        Array.Resize(ref NewSet.Answers, NewSet.Answers.Length + 1);
                        NewSet.Answers[^1] = GetAnswer;

                        break;

                    case ConsoleKey.S:
                        Console.WriteLine("\n\n--Saved!--");
                        Thread.Sleep(1000);
                        Main();

                        break;

                    default:
                        continue;
                }
            
            } 

        }

        static void CreateFromFile()
        {
            Console.Clear();

            Console.Write("[!] Write the name of your file, like <example.txt>: ");
            string? filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                Console.Clear();

                //Reading from file
                string[] fileLines = File.ReadAllLines(filePath);

                //Creating new set
                Console.Write("Write a set name: ");
                string name = Console.ReadLine();
                NewSet = new Set(name);

                Console.Clear();

                Array.Resize(ref NewSet.Questions, fileLines.Length / 2);
                Array.Resize(ref NewSet.Answers, fileLines.Length / 2);

                int oddIndex = 0;
                int evenIndex = 0;
                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        NewSet.Questions[oddIndex] = fileLines[i];
                        oddIndex++;
                    }
                    else
                    {
                        NewSet.Answers[evenIndex] = fileLines[i];
                        evenIndex++;
                    }
                }

                Array.Resize(ref Sets, Sets.Length + 1);
                Sets[^1] = NewSet;

                NewSet.ShowInfo();
                Thread.Sleep(1000);
                Console.WriteLine("[!] Everything added successfuly! Press any key to continue.\n");
                                
                Console.ReadLine();
                Main();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"[!] Sorry, file with name \'{filePath}\' doesn't seem to exist. Please, try again.");
                Thread.Sleep(2000);
                Main();
            }
        }

        //Testing selected set
        static void TestList()
        {
            Console.Clear();
            Console.WriteLine("now we will testing you =)");
        }

        static void SetInfo()
        {
            Console.Clear();

            if (Sets.Length == 0)
            {
                Console.WriteLine("[!] You haven't got any sets!");
                Thread.Sleep(2000);
                Main();
            }
            else
            {
                Console.WriteLine("[!] Press \'any key\' to back to screen.\n");

                for (int i = 0; i < Sets.Length; i++)
                {
                    Console.Write($"Set id = \'{i + 1}\', "); //The end of this row is comma, because in Set.ShowInfo() it's continue, some shitcodding ;)
                    Sets[i].ShowInfo();
                }

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    default:
                        StartScreen();
                        break;
                }
            }
        }

        static void DeleteSets()
        {
            Console.Clear();

            if (Sets.Length == 0)
            {
                Console.WriteLine("[!] You haven't got any sets!");
                Thread.Sleep(2000);
                Main();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[!] Warning [!] All your sets will be delete.");
                Console.WriteLine("[!] Press \'Y\' to continue, or \'N\' to back to start screen.");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Sets = Array.Empty<Set>();
                    Console.WriteLine("[*] All sets successfully have been deleted!");
                    Thread.Sleep(2000);
                    Main();
                }
                else
                {
                    Main();
                }
            }
        }
    }
}