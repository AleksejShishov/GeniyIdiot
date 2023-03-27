using System;
using System.Collections.Generic;
using System.IO;

namespace GeniyIdiiotConsoleApp
{

    public class QuestionsRepository
    {
        private string questionsRepoFilePath;

        private List<Question> defaultQuestions = new List<Question>()
        { 
                new Question("Сколько будет два плюс два умноженное на два?", 6),
                new Question("Бревно нужно разделить на 10 частей, сколько нужно сделать распилов?", 9),
                new Question("На двух руках 10 пальцев, cколько пальцев на 5 руках?", 25),
                new Question("Укол делают каждые полчаса, сколько нужно минут для трёх уколов?", 60),
                new Question("Пять свечей горело до конца, но две потухли заранее. сколько свечей осталось?", 2),
        };

        private List<Question> questions;

        public int Count() { return questions.Count; }

        public QuestionsRepository(string path)
        { 
            questionsRepoFilePath = path;

            if (!FileProvider.Exists(questionsRepoFilePath)) 
            {
                foreach (var question in defaultQuestions) { Save(question); }
            }
            else 
            {
                questions = Load(false);
            }
        }
         
        public  List<Question> Load(bool keyOutput)
        {
                var results = new List<Question>();

                var value = FileProvider.GetValue(questionsRepoFilePath);

                var lines = value.Split('\n');

                var counter = 0;

                foreach (var line in lines)
                {
                    if (line != "")
                    {
                        var words = line.Split('#');
                        var text = words[0];
                        var answer = Convert.ToInt32(words[1]);
                        var question = new Question(text, answer);

                        if (keyOutput) Console.WriteLine("{0}.  {1}",++counter, text);
                        results.Add(question);
                    }
                }
                return results;
        }

        public void Save(Question newQuestion)
        {
            var line = $"{newQuestion.GetQuestion()}#{newQuestion.GetRightAnswer()}";
            FileProvider.AppendValue(questionsRepoFilePath, line);
        }

        public string GetCurrentQuestion (int index) { return questions[index].GetQuestion();  }

        public int GetCurrentAnswer (int index) { return questions[index].GetRightAnswer();  }

        public void RemoveCurrentQuestion (int index) { questions.RemoveAt(index); }

        public void Remove(int questionNum)
        {
            questions.RemoveAt(questionNum);

            FileProvider.Clear(questionsRepoFilePath);

            foreach (var question in questions) { Save(question); }

        }

    }
}