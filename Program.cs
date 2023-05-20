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

            ConsoleWrite.LineWhite("Hello, my name is Wordix! I help people to remember words easyest =)\n");
            ConsoleWrite.LineWhite("[N] - to create a new word-list.");
            ConsoleWrite.LineWhite("[R] - to copy a new word-list from the file.");
            ConsoleWrite.LineWhite("[T] - to make a test.");
            ConsoleWrite.LineWhite("[I] - to see Set-Info.");
            ConsoleWrite.LineWhite("[D] - to delete all sets.");
            ConsoleWrite.LineWhite("[Q] - to quit.");

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
            ConsoleWrite.White("Write a set name: ");
            string? name = Console.ReadLine();
            NewSet = new Set(name);

            //Creating file name
            string filePath = name + ".txt";

            //Adding new set into array
            Array.Resize(ref Sets, Sets.Length + 1);
            Sets[^1] = NewSet;

            while(true) 
            {
                ConsoleWrite.LineGreen("\n[*] Press \'+\' to add a question-answer block or \'S\' to exit");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.OemPlus:

                        //Addind a question
                        ConsoleWrite.LineWhite("\n1) Add a question");
                        string? GetQuestion = Console.ReadLine();

                        Array.Resize(ref NewSet.Questions, NewSet.Questions.Length + 1);
                        NewSet.Questions[^1] = GetQuestion;

                        //Adding question to the file
                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {
                            writer.WriteLine(GetQuestion);
                        }

                        //Addind a answer
                        ConsoleWrite.LineWhite("\n2) Add an answer");
                        string? GetAnswer = Console.ReadLine();

                        //Adding answer to the file
                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {
                            writer.WriteLine(GetAnswer);
                        }

                        Array.Resize(ref NewSet.Answers, NewSet.Answers.Length + 1);
                        NewSet.Answers[^1] = GetAnswer;

                        break;

                    case ConsoleKey.S:
                        ConsoleWrite.LineGreen("\n\n--Saved!--");
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

            ConsoleWrite.White("[*] Write the name of your file, like <example.txt>: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                Console.Clear();

                //Reading from file
                string[] fileLines = File.ReadAllLines(filePath);

                //Creating new set
                ConsoleWrite.White("Write a set name: ");
                string? name = Console.ReadLine();
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
                ConsoleWrite.LineGreen("[*] Everything added successfuly! Press any key to continue.\n");
                                
                Console.ReadLine();
                Main();
            }
            else
            {
                Console.Clear();
                ConsoleWrite.LineRed($"[!] Sorry, file with name \'{filePath}\' doesn't seem to exist. Please, try again.");
                Thread.Sleep(2000);
                Main();
            }
        }

        //Testing selected set
        static void TestList()
        {
            if (Sets.Length == 0)
            {
                Console.Clear();
                ConsoleWrite.LineRed("[!] Sorry, you haven't got any sets, create them or import from the file.");
                Thread.Sleep(2000);
                Main();
            }
            else
            {
                Console.Clear();

                ConsoleWrite.White("[*] Specify the id of the set you want to test: ");
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    ConsoleWrite.LineRed("[!] Invalid ID, try again!");
                    Thread.Sleep(1000);
                    Main();
                }

                if (id < 1 || id > Sets.Length)
                {
                    ConsoleWrite.LineRed("[!] Invalid ID, try again!");
                    Thread.Sleep(1000);
                    Main();
                }

                ConsoleWrite.LineWhite("[*] We will test this set: \n");
                Sets[id - 1].ShowInfo();
                ConsoleWrite.LineGreen("\n[*] Press ENTER to continue.");
                Console.ReadLine();

                int correctAnswers = 0;
                int totalQuestions = 0;
                float resultInPersents = 0f;

                while (totalQuestions != Sets[id - 1].Questions.Length * 2)
                {
                    Console.Clear();
                    totalQuestions++;

                    Random random = new();
                    int index = random.Next(Sets[id - 1].Questions.Length);
                    string RandomQuestion = Sets[id - 1].Questions[index];

                    string? CheckAnswer;

                    do
                    {
                        Console.Clear();
                        ConsoleWrite.LineWhite("Question:");
                        Console.WriteLine(RandomQuestion + "\n");

                        ConsoleWrite.LineWhite("Answer:");
                        CheckAnswer = Console.ReadLine();

                        if (string.Equals(CheckAnswer, Sets[id - 1].Answers[index]))
                        {
                            correctAnswers++;
                        }
                        else
                        {
                            correctAnswers--;
                        }
                    } while (!string.Equals(CheckAnswer, Sets[id - 1].Answers[index]));

                    ConsoleWrite.LineGreen("\n[*] Correct!");
                    Thread.Sleep(1000);
                }

                resultInPersents = (float)correctAnswers / totalQuestions * 100;
                Console.Clear();
                if (resultInPersents <= 0)
                {
                    ConsoleWrite.LineWhite("Percentage: 0.00%");
                }
                else
                {
                    ConsoleWrite.LineWhite($"Percentage: {resultInPersents}%");
                }

                ConsoleWrite.LineGreen("[*] Press any key to continue.");

                Console.ReadLine();
                Main();
            }
        }

        static void SetInfo()
        {
            Console.Clear();

            if (Sets.Length == 0)
            {
                ConsoleWrite.LineRed("[!] You haven't got any sets!");
                Thread.Sleep(2000);
                Main();
            }
            else
            {
                ConsoleWrite.LineWhite("[*] Press \'any key\' to back to screen.\n");

                for (int i = 0; i < Sets.Length; i++)
                {
                    ConsoleWrite.White($"Set id = \'{i + 1}\', "); //The end of this row is comma, because in Set.ShowInfo() it's continue, some shitcodding ;)
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
                ConsoleWrite.LineRed("[!] You haven't got any sets!");
                Thread.Sleep(2000);
                Main();
            }
            else
            {
                Console.Clear();
                ConsoleWrite.LineRed("[!] Warning [!] All your sets will be delete.");
                ConsoleWrite.LineRed("[!] Press \'Y\' to continue, or \'N\' to back to start screen.");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Sets = Array.Empty<Set>();
                    ConsoleWrite.LineGreen("[*] All sets successfully have been deleted!");
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