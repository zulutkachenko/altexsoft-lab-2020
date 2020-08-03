using System;
using System.IO;
using System.Collections.Generic;

namespace altexsoft_lab_2020
{
    class countWord
    {
        mainMenu consoleMenu = new mainMenu();
        public void count()
        {
            string str = File.ReadAllText(@"textSample.txt");

            char[] charsToRemove = new char[] { '?', ',', '.', ';', '(', ')' };
            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), string.Empty);
            }
            
            string[] words = str.Split(' ');

            Console.WriteLine("\nWord count/Количество слов: " + words.Length);

            List<string> termsList = new List<string>();
            for (int i = 10; i < words.Length; i += 10)
            {
                termsList.Add(words[i - 1]);
            }
                string ffr = String.Join(", ", termsList);
                Console.WriteLine("\nEvery tenth word/Каждое 10-ое слово: " + ffr);


            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                consoleMenu.Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");

        }

    }
}
