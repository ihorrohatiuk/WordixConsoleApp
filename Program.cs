using System;

public class Set
{
    public string name;
    public string[] Questions = Array.Empty<string>();
    public string[] Answers = Array.Empty<string>();

    public Set(string? name)
    {
        this.name = name;
    }

    public void SetInfo()
    {
        Console.WriteLine($"Set name: \'{name}\'");

        Console.WriteLine($"Set questions: \n");
        foreach (var i in Questions)
        {
            Console.WriteLine($"\t{i}");
        }

        Console.WriteLine($"Set answers: \n");
        foreach (var i in Answers)
        {
            Console.WriteLine($"\t{i}");
        }
    }
}

internal class WordixConsoleApp
{
    public static void Main()
    {
        Console.Clear();
        
        StartScreen();
    }

    public static void StartScreen()
    {
        Console.Clear();

        Console.WriteLine("Hello, my name is Wordix! I help people to remember words easyest =)\n");
        Console.WriteLine("[N] - to create a new word-list.");
        Console.WriteLine("[T] - to make a test.");
        Console.WriteLine("[I] - to see Set-Info.");
        Console.WriteLine("[Q] - to quit.");

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.N:
                CreateSet();
                break;
            case ConsoleKey.T:
                TestList();
                break;
            case ConsoleKey.Q:
                return;
            case ConsoleKey.I:
                SetInfo();
                return;
            default:
                StartScreen();
                break;
        }
    }

    //Creating a new SET
    public static void CreateSet()
    {
        Console.Clear();

        //Addind a NAME
        Console.Write("Write a set name: ");
        string? name = Console.ReadLine();
        Set NewSet = new Set(name); //?????Should that declaration be here?

        while (true) // ?????????????Remake to DO-WHILE
        {
            //Addind a question
            Console.WriteLine("1) Add a question");
            string GetQuestion = Console.ReadLine();

            Array.Resize(ref NewSet.Questions, NewSet.Questions.Length + 1);
            NewSet.Questions[^1] = GetQuestion;

            //Addind a answer
            Console.WriteLine("2) Add an answer");
            string GetAnswer = Console.ReadLine();

            Array.Resize(ref NewSet.Answers, NewSet.Answers.Length + 1);
            NewSet.Answers[^1] = GetAnswer;

            //Exit control 
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q)
            { 
                Main();
                return;
            }
        }

    }

    //Testing selected set
    public static void TestList()
    {
        Console.Clear();
        Console.WriteLine("now we will testing you =)");
    }

    public static void SetInfo()
    {
        //
    }
}