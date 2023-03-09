using System;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {
        static string[] GetQuestions(int countQuestion) 
        {
            string[] questions = new string[countQuestion];
            questions[0] = "Сколько будет 2 плюс 2, умноженное на 2?";
            questions[1] = "Бревно нужно разделить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно миинут для трёх уколов?";
            questions[4] = "Пять свечей горело до конца, но две потухли заранее. Сколько свечей осталось?";
            return questions;
        }

        static string[] GetDiagnose(int countQuestion) 
        {
            string[] diagnose = new string[countQuestion + 1];
            diagnose[0] = "идиот";
            diagnose[1] = "кретин";
            diagnose[2] = "дурак";
            diagnose[3] = "нормальный";
            diagnose[4] = "таланнт";
            diagnose[5] = "гений";
            return diagnose;
        }

        static int[] GetRightAnswer(int countQuestion) 
        {
            int[] answers = new int[countQuestion];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static void Main(string[] args)
        {
            int countQuestion = 5;

            string[] questions = GetQuestions(countQuestion);

            int[] answers = GetRightAnswer(countQuestion);
           
            string[] diagnose  = GetDiagnose(countQuestion+1);
            
            Random random = new Random();

            // Добавим массив, который будем заполнять случайным образом
            int[] arrayForMixed = new int[countQuestion];
            // Заполним массив линейно
            for (int i = 0; i < countQuestion; i++)
            {
                arrayForMixed[i] = i;
            }
            // Перетасуем массив с помощью random
            for (int i = countQuestion - 1; i >= 0; i--)
            {
                int temp = arrayForMixed[i];
                int nextRandom = random.Next(0,countQuestion);
                arrayForMixed[i] = arrayForMixed[nextRandom];
                arrayForMixed[nextRandom] = temp;
            }

            int countRightAnswers = 0;

            for (int counter=0; counter<countQuestion; counter++)
            {
                //int randomQuestionIndex = random.Next(0,5)  ;
                Console.WriteLine("Вопрос номер " + (counter+1));
                Console.WriteLine(questions[arrayForMixed[counter]]);
                
                int userAnswer = Convert.ToInt32(Console.ReadLine());

                int rightAnswer = answers[arrayForMixed[counter]];

                if (userAnswer == rightAnswer)
                { 
                countRightAnswers++;
                }

            }

            Console.WriteLine("Количество правильных решений: " + countRightAnswers);
            Console.WriteLine("Ваш диагноз: Вы - " + diagnose[countRightAnswers]);
           // Console.WriteLine("Ваш диагноз: Вы - " + diagnose[countRightAnswers]);

        }
    }
}
