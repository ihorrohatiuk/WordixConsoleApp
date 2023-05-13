﻿using System;
using System.Threading; //for delay

public class Set
{
    public string name;
    public string[] Questions = Array.Empty<string>();
    public string[] Answers = Array.Empty<string>();

    public Set(string? name)
    {
        this.name = name;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Set name: \'{name}\'\n");
        
        //Finding the longest QUESTION
        string maxQuestion = Questions[0];
        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i].Length > maxQuestion.Length)
            {
                maxQuestion = Questions[i];
            }
        }

        //Finding the longest ANSWER
        string maxAnswer = Answers[0];
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].Length > maxAnswer.Length)
            {
                maxAnswer = Answers[i];
            }
        }

        Console.Write("    Question:");

        for (int j = 0; j < maxQuestion.Length - 9; j++)
        {
            Console.Write(" ");
        }

        Console.WriteLine("    Answer:");


        Console.Write("    ");
        for (int i = 0; i < maxQuestion.Length; i++)
        {
            Console.Write("─");
        }
        Console.Write("    ");
        for (int i = 0; i < maxAnswer.Length; i++)
        {
            Console.Write("─");
        }
        Console.Write("\n");

        for (int i = 0; i < Questions.Length; i++)
        {
            Console.Write($"    {Questions[i]}");

            for (int j = 0; j < maxQuestion.Length - Questions[i].Length; j++)
            {
                Console.Write(" ");
            }

            Console.WriteLine($"    {Answers[i]}");              
        }
    }
}

internal class WordixConsoleApp
{
    private static Set NewSet;

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
                Environment.Exit(0);
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
    static void CreateSet()
    {
        Console.Clear();

        //Addind a NAME
        Console.Write("Write a set name: ");
        string? name = Console.ReadLine();
        NewSet = new Set(name); //?????Should that declaration be here?

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

    //Testing selected set
    static void TestList()
    {
        Console.Clear();
        Console.WriteLine("now we will testing you =)");
    }

    static void SetInfo()
    {
        Console.Clear();

        NewSet.ShowInfo();

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            default:
                StartScreen();
                break;
        }
    }
}