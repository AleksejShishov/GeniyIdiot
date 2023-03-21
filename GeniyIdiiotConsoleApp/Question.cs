
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniyIdiiotConsoleApp
{

   
    public class Question
    {
        private string question;
        private int answer;

        public Question(string line, int value)
        {
            question = line;
            answer = value;
        }

        public string GetQuestion() { return question; }

        public int GetRightAnswer() { return answer; }
    }

}


