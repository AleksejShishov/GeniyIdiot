﻿using System;
using System.Collections.Generic;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {

        const int diagnosesMaxNumber = 6;
        const int questionsMaxNumber = 5;


        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Здравствуйте! Введите своё имя:");
                string userName = Console.ReadLine();

                string[] questions = GetQuestions();

                int[] answers = GetAnswers();

                string[] diagnoses = GetDiagnoses();

                int[] arrayForMixed = GetRandomArray();

                int countRightAnswers = 0;

                for (int counter = 0; counter < questionsMaxNumber; counter++)
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

                float adjustedCountRightAnswers = (float)countRightAnswers / questionsMaxNumber;
                adjustedCountRightAnswers = adjustedCountRightAnswers * (diagnosesMaxNumber - 1);  
 
                Console.WriteLine("Количество правильных решений: " + countRightAnswers);
                Console.WriteLine("Уважаемый(ая) " + userName + ", ваш диагноз: " + diagnoses[(int)adjustedCountRightAnswers]);

                bool userChoice = GetUsersChoice("Желаете повторить тест? ");
                if (userChoice == false)
                {
                    break;
                }
            }
        }


        static string[] GetQuestions()
        {
            string[] questions = new string[questionsMaxNumber];
            questions[0] = "сколько будет 2 плюс 2, умноженное на 2?";
            questions[1] = "бревно нужно разделить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "на двух руках 10 пальцев. сколько пальцев на 5 руках?";
            questions[3] = "укол делают каждые полчаса, сколько нужно миинут для трёх уколов?";
            questions[4] = "пять свечей горело до конца, но две потухли заранее. сколько свечей осталось?";
            return questions;
        }

        static int[] GetAnswers()
        {
            int[] answers = new int[questionsMaxNumber];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static string[] GetDiagnoses()
        {
            string[] diagnose = new string[diagnosesMaxNumber];
            diagnose[0] = "идиот";
            diagnose[1] = "кретин";
            diagnose[2] = "дурак";
            diagnose[3] = "нормальный";
            diagnose[4] = "таланнт";
            diagnose[5] = "гений";
            return diagnose;
        }

        static int[] GetRandomArray()
        {
            Random random = new Random();
            int[] arrayForMixed = new int[questionsMaxNumber];

            for (int counter = 0; counter < questionsMaxNumber; counter++)
            {
                arrayForMixed[counter] = counter;
            }

            for (int counter = questionsMaxNumber - 1; counter >= 0; counter--)
            {
                int temp = arrayForMixed[counter];
                int nextRandom = random.Next(0, questionsMaxNumber);
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
