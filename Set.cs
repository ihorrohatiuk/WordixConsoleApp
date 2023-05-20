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
            ConsoleWrite.LineWhite($"set name: \'{name}\' \n");

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

            ConsoleWrite.White("    Question:");

            for (int j = 0; j < maxQuestion.Length - 9; j++)
            {
                ConsoleWrite.White(" ");
            }

            ConsoleWrite.LineWhite("    Answer:");


            ConsoleWrite.White("    ");
            for (int i = 0; i < maxQuestion.Length; i++)
            {
                ConsoleWrite.White("─");
            }
            if (maxQuestion.Length >= 9)
            {
                ConsoleWrite.White("    ");
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
                ConsoleWrite.White("─");
            }
            Console.Write("\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                ConsoleWrite.White($"    {Questions[i]}");

                if (maxQuestion.Length >= 9)
                {
                    for (int j = 0; j < maxQuestion.Length - Questions[i].Length; j++)
                    {
                        ConsoleWrite.White(" ");
                    }
                }
                else
                {
                    for (int j = 0; j < 9 - Questions[i].Length; j++)
                    {
                        ConsoleWrite.White(" ");
                    }
                }
                ConsoleWrite.LineWhite($"    {Answers[i]}");
            }

            Console.Write("\n");
        }
    }
}
