using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {

        const int QuestionsCount = 5;
        const string ResultTxtFileName = "user_res.txt";



        static void Main(string[] args)
        {
            Random random = new Random();

            while (true)            
            {               
                Console.WriteLine("Здравствуйте! Введите своё имя:");
                var userName = Console.ReadLine();
                Console.WriteLine();

                var questions = GetQuestions();
                var answers = GetAnswers();
                            
                int countRightAnswers = 0;

                for (int counter = 0; counter < QuestionsCount; counter++)
                {
                    Console.WriteLine($"Вопрос номер {counter + 1}");
                    
                    var randomQuestionIndex = random.Next(questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex]);

                    int userAnswer = GetUsersAnswer();

                    int rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                string diagnose = GetDiagnose(countRightAnswers);
                Console.WriteLine("\nКоличество правильных решений: " + countRightAnswers);
                Console.WriteLine("Уважаемый(ая) " + userName + ", ваш диагноз: " + diagnose);

                SaveUserResult(userName, countRightAnswers, diagnose);

                bool userChoice = GetUsersChoice("\nЖелаете посмотреть результаты? ");
                if (userChoice)
                {
                    ShowUserResults();
                }

                userChoice = GetUsersChoice("\nЖелаете повторить тест? ");
                if (!userChoice)
                {
                    break;
                }

                Console.Clear();
            }
        }

        static void ShowUserResults()
        {
            var reader = new StreamReader(ResultTxtFileName, Encoding.UTF8);

            var outputFormat = "{0,-20}|{1,-20}|{2,-20}|";
            Console.WriteLine("\n{0,40}\n", "РЕЗУЛЬТАТЫ :");
            Console.WriteLine(outputFormat, "Имя пользователя", "Правильных ответов", "Диагноз");
            Console.WriteLine("{0,20}{0,20}{0,20}", "_____________________");

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var words = line.Split('#');
                
                Console.WriteLine(outputFormat, words);
            }
            reader.Close();
        }
        static void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            var line = $"{userName}#{countRightAnswers}#{diagnose}";
            AppendToFile(ResultTxtFileName, line);
        }

        static void AppendToFile(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        static List<string> GetQuestions()
        {
            var questions = new string[QuestionsCount];
            questions[0] = "Сколько будет 2 плюс 2 умноженное на 2?";
            questions[1] = "Бревно нужно разделить на 10 частей, сколько нужно сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно миинут для трёх уколов?";
            questions[4] = "Пять свечей горело до конца, но две потухли заранее. сколько свечей осталось?";
            return questions.ToList();
        }

        static List<int> GetAnswers()
        {
            var answers = new int[QuestionsCount];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers.ToList();
        }

        static string GetDiagnose(int countRightAnswers)
        {
            var diagnoses = new string[] { "идиот", "кретин", "дурак", "нормальный", "талант", "гений" };
        
            float adjustedCountRightAnswers = (float)countRightAnswers / QuestionsCount * (diagnoses.Length - 1);

            return diagnoses[(int)adjustedCountRightAnswers];
        }

       
        static int GetUsersAnswer()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var userAnswer))
                {
                      return userAnswer;
                }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите целое число в диапозоне [ -2 147 483 648; 2 147 483 647]!");
                    Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static bool GetUsersChoice(string message)
        {
                Console.WriteLine(message + "Введите Да или любой другой ответ для - Нет:");
                string userInput = Console.ReadLine();
                return userInput.ToUpper() == "ДА" ?  true :  false;
        }


    }
}
