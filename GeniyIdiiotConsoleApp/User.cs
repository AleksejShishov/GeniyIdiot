using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiiotConsoleApp
{
    public class User
    {
        private string name;
        private int countRightAnswers;
        private string diagnose;

        public User()
        {
            Console.WriteLine("Здравствуйте! Введите своё имя:");
            name = Console.ReadLine();
            Console.WriteLine();
        }

        public void icreaseCountRightAnswer()
        {
            ++countRightAnswers;
        }

        public int GetCountRightAnswers() { return countRightAnswers; }

        public string GetName() { return name; }

        public string GetDiagnose() { return diagnose; }
        public void SetDiagnose(string value) { diagnose = value; }

        public int GetUserAnswer()
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
    }
}
