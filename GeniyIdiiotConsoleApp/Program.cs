using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();

            while (true)
            {

                var user = new User();

                var resultRepository = new UsersResultRepository("user_res.txt");

                var questions = new QuestionsRepository();

                int countQuestions = questions.Count();


                for (int counter = 0; counter < countQuestions; counter++)
                {
                    Console.WriteLine($"Вопрос номер {counter + 1}");

                    var randomQuestionIndex = random.Next(questions.Count());
                    Console.WriteLine(questions.questions[randomQuestionIndex].GetQuestion());


                    if (user.GetUserAnswer() == questions.questions[randomQuestionIndex].GetRightAnswer())
                    {
                        user.icreaseCountRightAnswer();
                    }

                    questions.questions.RemoveAt(randomQuestionIndex);
                }

                var assessment = new Diagnoses ();
                user.SetDiagnose(assessment.GetDiagnose(user.GetCountRightAnswers(), countQuestions));

                resultRepository.ShowUserResults(user.GetName(), user.GetCountRightAnswers(), user.GetDiagnose());

                 bool userChoice = GetUsersChoice("\nЖелаете посмотреть результаты? ");
                if (userChoice)
                {
                    resultRepository.ShowUserResultsFromFile();
                }

                userChoice = GetUsersChoice("\nЖелаете повторить тест? ");
                if (!userChoice)
                {
                    break;
                }

                Console.Clear();
            }
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
            return userInput.ToUpper() == "ДА" ? true : false;
        }


    }
}
