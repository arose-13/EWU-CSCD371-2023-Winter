using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);
            ShuffleQuestions(questions);

            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            decimal percentage = ((decimal)numberCorrectAnswers / numberOfQuestions * 100);
            return (int)percentage + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;

                questions[i] = question;
            }
            return questions;
        }

        public static void ShuffleQuestions(Question[] questions)
        {
            int[] indexesToShuffle = new int[2];
            Question temp;

            for (int i = 0; i < questions.Length/2; i++)
            {
                indexesToShuffle = GetRandomIndexes(questions.Length);

                temp = questions[indexesToShuffle[0]];
                questions[indexesToShuffle[0]] = questions[indexesToShuffle[1]];
                questions[indexesToShuffle[1]] = temp;
            }
        }

        public static int[] GetRandomIndexes(int maxValue)
        {
            Random randomInt = new Random();
            int[] indexes = new int[] { randomInt.Next(maxValue), randomInt.Next(maxValue) };

            while (indexes[0] == indexes[1])
            {
                indexes[0] = randomInt.Next(maxValue);
                indexes[0] = randomInt.Next(maxValue);
            }

            return indexes;
        }
    }
}
