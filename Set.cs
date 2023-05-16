using System;

namespace WordixConsoleApp
{
    class Set
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
            Console.WriteLine($"set name: \'{name}\' \n");

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
            if (maxQuestion.Length >= 9)
            {
                Console.Write("    ");
            }
            else
            {
                for (int i = 0; i < 9 - maxQuestion.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("    ");
            }
            for (int i = 0; i < maxAnswer.Length; i++)
            {
                Console.Write("─");
            }
            Console.Write("\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"    {Questions[i]}");

                if (maxQuestion.Length >= 9)
                {
                    for (int j = 0; j < maxQuestion.Length - Questions[i].Length; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    for (int j = 0; j < 9 - Questions[i].Length; j++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine($"    {Answers[i]}");
            }

            Console.Write("\n");
        }
    }
}
