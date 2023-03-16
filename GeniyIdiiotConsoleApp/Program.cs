using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {

        const int Diagnoses_Max_Number = 6;
        const int Questions_Max_Number = 5;
        const string Result_Txt_File_Name = "user_res.txt";



        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Здравствуйте! Введите своё имя:");
                string userName = Console.ReadLine();

                string[] questions = GetQuestions();

                int[] answers = GetAnswers();

                int[] arrayForMixed = GetRandomArray();

                int countRightAnswers = 0;

                for (int counter = 0; counter < Questions_Max_Number; counter++)
                {
                    Console.WriteLine("Вопрос номер " + (counter + 1));
                    Console.WriteLine(questions[arrayForMixed[counter]]);

                    int userAnswer = GetUsersAnswer();

                    int rightAnswer = answers[arrayForMixed[counter]];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }

                }

                string diagnose = GetDiagnose(countRightAnswers);
                Console.WriteLine("Количество правильных решений: " + countRightAnswers);
                Console.WriteLine("Уважаемый(ая) " + userName + ", ваш диагноз: " + diagnose);

                SaveUserResult(userName, countRightAnswers, diagnose);

                bool userChoice = GetUsersChoice("Желаете посмотреть результаты? ");
                if (userChoice == true)
                {
                    Console.WriteLine("\n РЕЗУЛЬТАТЫ : \n");
                    ShowUserResults();
                }

                userChoice = GetUsersChoice("Желаете повторить тест? ");
                if (userChoice == false)
                {
                    break;
                }
            }
        }

        static void ShowUserResults()
        {
            StreamReader reader = new StreamReader(Result_Txt_File_Name, Encoding.UTF8);
            var line = reader.ReadToEnd();
            ShowResultsTable(line);
            reader.Close();
        }

        static void ShowResultsTable(string line)
        {
            string[] words = line.Split('#');
            foreach (String word in words)
            {
                //  Console.Write((word.EndsWith("!")) ? word.Remove(word.Length-2, 1) + "\n" : word + " ");
                Console.Write(word + " ");
            }

        }

        static void SaveUserResult(string UserName, int countRightAnswers, string diagnose)
        {
            //           string line = $"{UserName}#{countRightAnswers}#{diagnose}!";
            string line = $"{UserName}#{countRightAnswers}#{diagnose}";
            AppendToFile(Result_Txt_File_Name, line);
        }

        static void AppendToFile(string fileName, string line)
        {
            StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(line);
            writer.Close();
        }

        static string[] GetQuestions()
        {
            string[] questions = new string[Questions_Max_Number];
            questions[0] = "Сколько будет 2 плюс 2 умноженное на 2?";
            questions[1] = "Бревно нужно разделить на 10 частей, сколько нужно сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно миинут для трёх уколов?";
            questions[4] = "Пять свечей горело до конца, но две потухли заранее. сколько свечей осталось?";
            return questions;
        }

        static int[] GetAnswers()
        {
            int[] answers = new int[Questions_Max_Number];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static string GetDiagnose(int countRightAnswers)
        {
            string[] diagnoses = new string[Diagnoses_Max_Number];
            diagnoses[0] = "идиот";
            diagnoses[1] = "кретин";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";

            float adjustedCountRightAnswers = (float)countRightAnswers / Questions_Max_Number;
            adjustedCountRightAnswers = adjustedCountRightAnswers * (Diagnoses_Max_Number - 1);

            return diagnoses[(int)adjustedCountRightAnswers];
        }

        static int[] GetRandomArray()
        {
            Random random = new Random();
            int[] arrayForMixed = new int[Questions_Max_Number];

            for (int counter = 0; counter < Questions_Max_Number; counter++)
            {
                arrayForMixed[counter] = counter;
            }

            for (int counter = Questions_Max_Number - 1; counter >= 0; counter--)
            {
                int temp = arrayForMixed[counter];
                int nextRandom = random.Next(0, Questions_Max_Number);
                arrayForMixed[counter] = arrayForMixed[nextRandom];
                arrayForMixed[nextRandom] = temp;
            }
            return arrayForMixed;

        }

        static int GetUsersAnswer()
        {
            int userAnswer;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите целое число в диапозоне [ -2 147 483 648; 2 147 483 647]!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return userAnswer;
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


    }
}
