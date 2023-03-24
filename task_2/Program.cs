using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите прописную русскую букву: ");
        char letter = Console.ReadLine().ToLower()[0];
        Console.Write("Выберите, должна ли буква быть в начале (1) или в конце (2) слова: ");
        int position = int.Parse(Console.ReadLine());

        string inputFile = "C:\\Users\\solidus66\\OneDrive\\ВГУ\\3 курс 2 сем\\ИТ (Вахтин)\\tasks\\solidus_tasks\\task2\\input.txt";
        string outputFile = "C:\\Users\\solidus66\\OneDrive\\ВГУ\\3 курс 2 сем\\ИТ (Вахтин)\\tasks\\solidus_tasks\\task2\\output.txt";

        Encoding encoding = Encoding.UTF8;
        StreamReader reader = new StreamReader(inputFile, encoding);
        StreamWriter writer = new StreamWriter(outputFile, false, encoding);

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] words = line.Split(' ', ',', '.', ':', ';', '-', '!', '?', '\t');
            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char firstChar = char.ToLower(word[0]);
                char lastChar = char.ToLower(word[word.Length - 1]);

                if (position == 1 && firstChar == letter || position == 2 && lastChar == letter)
                {
                    writer.Write(word);
                    writer.Write(' ');
                }
            }
        }

        reader.Close();
        writer.Close();
    }
}
