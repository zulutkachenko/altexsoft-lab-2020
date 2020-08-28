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
            string charsToRemove = "[@,()\t^$+\\.\";'\\\\]";

            Regex regex = new Regex(charsToRemove);
            string result = regex.Replace(consoleMenu.EnterFileName().ToString(), "");

            string[] words = result.Split(' ');

            Console.WriteLine("\nWord count/Количество слов: " + words.Length);

            List<string> termsList = new List<string>();
            for (int i = 10; i < words.Length; i += 10)
            {
                termsList.Add(words[i - 1]);
            }
            string glueWords = String.Join(", ", termsList);
            Console.WriteLine("\nEvery tenth word/Каждое 10-ое слово: " + glueWords);

            consoleMenu.closeMenu();
        }

    }
}
