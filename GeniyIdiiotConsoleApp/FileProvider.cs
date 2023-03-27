using System;
using System.IO;
using System.Text;

namespace GeniyIdiiotConsoleApp
{
    internal class FileProvider
    {
        public static void AppendValue(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        public static string GetValue(string fileName) 
        {
            var reader = new StreamReader(fileName, Encoding.UTF8);
            var value = reader.ReadToEnd();
            reader.Close();
            return value;
        }

        public static bool Exists(string filePath)
        {
           return  File.Exists(filePath);
        }

        internal static void Clear(string filePath)
        {
            File.WriteAllText(filePath, string.Empty);
        }
    }
}
