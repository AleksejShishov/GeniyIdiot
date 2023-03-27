using System;

namespace GeniyIdiiotConsoleApp
{
    public class User
    {
        private string name;
        private int countRightAnswers;
        private string diagnose;

        public User()
        {
            name = ConsoleProvider.UserInit();
        }

        public User(string name, int countRightAnswers, string diagnose)
        {
            this.name = name;
            this.countRightAnswers = countRightAnswers; 
            this.diagnose = diagnose;
        }

        public void IncreaseCountRightAnswer()
        {
            ++countRightAnswers;
        }

        public int GetCountRightAnswers() { return countRightAnswers; }

        public string GetName() { return name; }

        public string GetDiagnose() { return diagnose; }
        public void SetDiagnose(string value) { diagnose = value; }
    }
}
