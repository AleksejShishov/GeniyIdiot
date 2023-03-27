using System;

namespace GeniyIdiiotConsoleApp
{
    public class Diagnoses
    {
       private string[] diagnoses = new string[] { "идиот", "кретин", "дурак", "нормальный", "талант", "гений" };

        public string GetDiagnose (int countRightAnswers, int countQuestions)
        {

            float adjustedCountRightAnswers = (float)countRightAnswers / countQuestions * (diagnoses.Length - 1);

            return diagnoses[(int)adjustedCountRightAnswers];
        }
    }
}
