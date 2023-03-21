using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GeniyIdiiotConsoleApp
{
    public  class UsersResultRepository
    {
        private string ResultTxtFileName;

        public UsersResultRepository(string value) { ResultTxtFileName = value; }

        private void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            var line = $"{userName}#{countRightAnswers}#{diagnose}";
            AppendToFile(ResultTxtFileName, line);
        }

        private void AppendToFile(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        public void ShowUserResultsFromFile()
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

        public void ShowUserResults(string userName, int countRightAnswers, string diagnose)
        {
            Console.WriteLine("\nКоличество правильных решений: " + countRightAnswers);
            Console.WriteLine("Уважаемый(ая) " + userName + ", ваш диагноз: " + diagnose);

            SaveUserResult(userName, countRightAnswers, diagnose);

        }

    }
}
