using System;

namespace GeniyIdiiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countQuestion = 5;

            string[] questions = new string[countQuestion];
            questions[0] = "Сколько будет 2 плюс 2, умноженное на 2?";
            questions[1] = "Бревно нужно разделить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно миинут для трёх уколов?";
            questions[4] = "Пять свечей горело до конца, но две потухли заранее. Сколько свечей осталось?";

            int[] answers = new int[countQuestion];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            string[] diagnose  = new string[countQuestion+1];
            diagnose[0] = "идиот";
            diagnose[1] = "кретин";
            diagnose[2] = "дурак";
            diagnose[3] = "нормальный";
            diagnose[4] = "таланнт";
            diagnose[5] = "гений";

            int countRightAnswers = 0;

            Random random= new Random();


            for (int counter=0; counter<countQuestion; counter++)
            {
                int randomQuestionIndex = random.Next(0,5)  ;
                Console.WriteLine("Вопрос номер " + (counter+1));
                Console.WriteLine(questions[randomQuestionIndex]);
                
                int userAnswer = Convert.ToInt32(Console.ReadLine());

                int rightAnswer = answers[randomQuestionIndex];

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
