using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Altexsoft_lab_2020
{
    class CountWord
    {
        NavMenu consoleMenu = new NavMenu();
        public void count()
        {
            if (System.IO.File.Exists(@"textSampled.txt"))
                Console.WriteLine("\nОткрываем файл...\n");
                else
                    Console.WriteLine("File <textSampled.txt> not found / Файл <textSampled.txt> не найден");

            string openFile = File.ReadAllText(@"textSampled.txt");

            string charsToRemove = "[@,()\t^$+\\.\";'\\\\]";

            Regex regex = new Regex(charsToRemove);
            string result = regex.Replace(openFile, "");
            
            string[] words = result.Split(' ');

            Console.WriteLine("\nWord count/Количество слов: " + words.Length);

            List<string> termsList = new List<string>();
            for (int i = 10; i < words.Length; i += 10)
            {
                termsList.Add(words[i - 1]);
            }
                string glueWords = String.Join(", ", termsList);
                Console.WriteLine("\nEvery tenth word/Каждое 10-ое слово: " + glueWords);


            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                consoleMenu.Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");

        }

    }
}
