using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniyIdiiotConsoleApp
{

    public class QuestionsRepository
    {
        public List<Question> questions = new List<Question>()
            {
                new Question("Сколько будет два плюс два умноженное на два?", 6),
                new Question("Бревно нужно разделить на 10 частей, сколько нужно сделать распилов?", 9),
                new Question("На двух руках 10 пальцев, cколько пальцев на 5 руках?", 25),
                new Question("Укол делают каждые полчаса, сколько нужно минут для трёх уколов?", 60),
                new Question("Пять свечей горело до конца, но две потухли заранее. сколько свечей осталось?", 2),
            };

        public int Count()
        {
            return questions.Count;
        }
    }
}