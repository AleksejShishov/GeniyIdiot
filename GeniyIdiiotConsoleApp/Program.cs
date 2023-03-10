using System;
using System.Collections.Generic;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine("Здравствуйте! Введите своё имя:");
                string userName = Console.ReadLine();

                int countQuestion = 5;

                string[] questions = GetQuestions(countQuestion);

                int[] answers = GetAnswers(countQuestion);

                string[] diagnoses = GetDiagnoses();

                int[] arrayForMixed = GetRandomArray(countQuestion);

                int countRightAnswers = 0;

                for (int counter = 0; counter < countQuestion; counter++)
                {
                    Console.WriteLine("Вопрос номер " + (counter + 1));
                    Console.WriteLine(questions[arrayForMixed[counter]]);

                    //  int useranswer = convert.toint32(console.readline());
                    int userAnswer;

                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out userAnswer))
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Пожалуйста, введите целое число!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    int rightAnswer = answers[arrayForMixed[counter]];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }

                }

                Console.WriteLine("Количество правильных решений: " + countRightAnswers);
                Console.WriteLine("Уважаемый(ая) " + userName + ", ваш диагноз: " + diagnoses[countRightAnswers]);

                bool userChoice = GetUsersChoice("Желаете повторить тест? ");
                if (userChoice == false)
                {
                    break;
                }
            }
        }


        static bool GetUsersChoice(string message)
        {
            while (true)
            {
                Console.WriteLine(message + "Введите Да или Нет:");
                string userInput = Console.ReadLine();

                if (userInput.ToUpper() == "ДА")
                {
                    return true;
                }
                if (userInput.ToUpper() == "НЕТ")
                {
                    return false;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ответ! ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static string[] GetQuestions(int countQuestion)
        {
            string[] questions = new string[countQuestion];
            questions[0] = "сколько будет 2 плюс 2, умноженное на 2?";
            questions[1] = "бревно нужно разделить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "на двух руках 10 пальцев. сколько пальцев на 5 руках?";
            questions[3] = "укол делают каждые полчаса, сколько нужно миинут для трёх уколов?";
            questions[4] = "пять свечей горело до конца, но две потухли заранее. сколько свечей осталось?";
            return questions;
        }

        static string[] GetDiagnoses()
        {
            string[] diagnose = new string[6];
            diagnose[0] = "идиот";
            diagnose[1] = "кретин";
            diagnose[2] = "дурак";
            diagnose[3] = "нормальный";
            diagnose[4] = "таланнт";
            diagnose[5] = "гений";
            return diagnose;
        }

        static int[] GetAnswers(int countQuestion)
        {
            int[] answers = new int[countQuestion];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static int[] GetRandomArray(int countQuestion)
        {
            Random random = new Random();
            int[] arrayForMixed = new int[countQuestion];

            for (int counter = 0; counter < countQuestion; counter++)
            {
                arrayForMixed[counter] = counter;
            }

            for (int counter = countQuestion - 1; counter >= 0; counter--)
            {
                int temp = arrayForMixed[counter];
                int nextRandom = random.Next(0, countQuestion);
                arrayForMixed[counter] = arrayForMixed[nextRandom];
                arrayForMixed[nextRandom] = temp;
            }
            return arrayForMixed;

        }
    }
}
