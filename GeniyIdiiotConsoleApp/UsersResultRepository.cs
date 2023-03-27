using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeniyIdiiotConsoleApp
{
    public class UsersResultRepository
    {
        private string repositoryPath;

        public UsersResultRepository(string value) { repositoryPath = value; }

        public string GetRepositoryPath() { return repositoryPath; }


        public void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            var line = $"{userName}#{countRightAnswers}#{diagnose}";
            FileProvider.AppendValue(repositoryPath, line);
        }

        public static List<User> GetUsersResults(string repositoryPath)
        {
            var results = new List<User>();

            var text = FileProvider.GetValue(repositoryPath);

            var lines = text.Split('\n');

             foreach (var line in lines)
            {
                if (line != "")
                {
                    var words = line.Split('#');
                    var name = words[0];
                    var countRightAnswers = Convert.ToInt32(words[1]);
                    var diagnose = words[2];
                    var user = new User(name, countRightAnswers, diagnose);
                    results.Add(user);
                }
            }

            return results;
        }

    }
}
