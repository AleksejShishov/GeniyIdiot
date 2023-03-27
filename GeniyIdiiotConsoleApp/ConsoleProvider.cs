using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeniyIdiiotConsoleApp
{
    public class ConsoleProvider
    {
        public static int Start()
        {
            Console.Clear();
            Console.WriteLine("{0,80}", "ПРОГРАММА ГЕНИЙ-ИДИОТ");
            Console.WriteLine("{0,75}", "М е н ю :");

            Console.WriteLine("1 - начать тестирование");
            Console.WriteLine("2 - посмотреть результаты всех участников");
            Console.WriteLine("3 - добавить новый вопрос");
            Console.WriteLine("4 - удалить вопрос по номеру");
            Console.WriteLine("0 - выход\n");

            return GetUserNumAnswer("Ваш выбор: ", 0, 4);
        }

        public static int GetUserNumAnswer() 
        {
            return GetUserNumAnswer("Пожалуйста, введите целое число в диапозоне [ -2 147 483 648; 2 147 483 647]: ", int.MinValue, int.MaxValue); 
        }

         public static int GetUserNumAnswer( string comment, int minValue, int maxValue)
              
        {
            Console.Write("Ваш ответ : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var userAnswer) && (userAnswer >= minValue) && (userAnswer <= maxValue) )
                {
                    return userAnswer;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(comment);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static string UserInit()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте! Введите своё имя:");
            return Console.ReadLine();
        }

        public static bool GetUsersChoiceYesNo(string message)
        {
            Console.WriteLine(message + "Введите Да или любой другой ответ для - Нет:");
            string userInput = Console.ReadLine();
            Console.Clear();

            return userInput.ToUpper() == "ДА" ? true : false;
        }

        public static void ShowUserResult(string userName, int countRightAnswers, string diagnose)
        {
            Console.WriteLine("\nКоличество правильных решений: " + countRightAnswers);
            Console.WriteLine("Уважаемый(ая) " + userName + ", ваш диагноз: " + diagnose);
        }

        internal static void ShowUsersResultTable(List<User> result)
        {
            Console.Clear();
            var outputFormat = "|{0,20}|{1,20}|{2,20}|";
            Console.WriteLine("\n{0,40}\n", "РЕЗУЛЬТАТЫ :");
            Console.WriteLine(outputFormat, "Имя пользователя", "Правильных ответов", "Диагноз");
            Console.WriteLine("{0,20}{0,20}{0,20}", "_____________________");

            foreach (var user in result)
            {
                Console.WriteLine(outputFormat, user.GetName(), user.GetCountRightAnswers(), user.GetDiagnose());
            }
            
            ConsoleProvider.Pause();
        }

        public static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public static Question AddNewQuestionInterface()
        {
            Console.Clear();
            Console.WriteLine("Введите текст вопроса:");
            var text = Console.ReadLine();
            Console.WriteLine("Введите правильный ответ на вопрос:");
            var answer = GetUserNumAnswer();

            var newQuestion = new Question(text, answer);
            return newQuestion;
        }

        internal static int RemoveQuestionInterface(QuestionsRepository item)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t Удаление вопроса.\n Нажмите 0 - выйти и не удалять вопрос. Или выберете номер удаляемого вопроса.\n");

            item.Load(true);

            var numberOfQuesstion = GetUserNumAnswer("Введите номер удаляемого вопроса вопроса: ", 0, item.Count());

            return numberOfQuesstion;
        }
    }
}
