using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GeniyIdiiotConsoleApp
{

    internal class Program
    {
        public static readonly string UserResultTxtFile = "user_res3.txt.";
        public static readonly string QuestionsAndAnswersTxtFile = "questions.txt";
 
        static void Main(string[] args)
        {
            var resultRepository = new UsersResultRepository(UserResultTxtFile);

            var questions = new QuestionsRepository(QuestionsAndAnswersTxtFile);

            var startGame = StartMenu(resultRepository, questions);

            while (startGame)
            {
                Random random = new Random();

                var user = new User();

                questions = new QuestionsRepository(QuestionsAndAnswersTxtFile); //reload after menu changes (add, remove)

                var countQuestions = questions.Count();

                for (int counter = 0; counter < countQuestions; counter++)
                {
                    Console.WriteLine($"Вопрос номер {counter + 1}");

                    var randomQuestionIndex = random.Next(questions.Count());

                    Console.WriteLine(questions.GetCurrentQuestion(randomQuestionIndex));

                    if (ConsoleProvider.GetUserNumAnswer() == questions.GetCurrentAnswer(randomQuestionIndex))
                    {
                        user.IncreaseCountRightAnswer();
                    }

                    questions.RemoveCurrentQuestion(randomQuestionIndex);
                }

                var result = new Diagnoses();

                var resultDiagnose = result.GetDiagnose(user.GetCountRightAnswers(), countQuestions);

                user.SetDiagnose(resultDiagnose);

                resultRepository.SaveUserResult(user.GetName(), user.GetCountRightAnswers(), user.GetDiagnose());

                ConsoleProvider.ShowUserResult(user.GetName(), user.GetCountRightAnswers(), user.GetDiagnose());

                ConsoleProvider.Pause();

                startGame = StartMenu(resultRepository, questions);
            }
        }

        static bool StartMenu(UsersResultRepository itemResults, QuestionsRepository itemQuestions)
        {
            var startMenu = true;
            var startGame = true;

            while (startMenu)
            {
                // 1 - старт теста пользователя(игры), 2 - таблица результатов, 3 - добавить вопрос, 4- удалить вопрос, 0 - выход
                switch (ConsoleProvider.Start())
                {
                    case 1:
                        startMenu = false;
                        break;
                    case 2:
                        var result = UsersResultRepository.GetUsersResults(itemResults.GetRepositoryPath());
                        ConsoleProvider.ShowUsersResultTable(result);
                        break;
                    case 3:
                        var newQuestion = ConsoleProvider.AddNewQuestionInterface();
                        itemQuestions.Save(newQuestion);
                        itemQuestions = new QuestionsRepository(QuestionsAndAnswersTxtFile);
                        break;
                    case 4:
                        var questionNum = ConsoleProvider.RemoveQuestionInterface(itemQuestions);
                        if (questionNum > 0)
                        {
                            itemQuestions.Remove(questionNum - 1);
                            itemQuestions = new QuestionsRepository(QuestionsAndAnswersTxtFile);
                        }
                        break;
                    default:
                        startGame = false;
                        startMenu = false;
                        break;
                }
            }
            return startGame;
        }
    }
}
