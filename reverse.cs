using System;
using System.IO;
using System.Linq;

namespace Altexsoft_lab_2020
{
    class Reverse
    {
        NavMenu consoleMenu = new NavMenu();
        public void reverseText()
        {
            Console.Clear();
                if (System.IO.File.Exists(@"textSampled.txt"))
                Console.WriteLine("\nOpen file / Открываем файл...\n");
                else
                    Console.WriteLine("File <textSampled.txt> not found / Файл <textSampled.txt> не найден");

            string[] openFile = File.ReadAllText(@"textSampled.txt").Split('.'); // открываем файл и разбиваем массив
            string secondSentence = new string(openFile[2]);
            string[] splitSentence = secondSentence.Split(' ');
            string[] reverseWord = splitSentence.Reverse().ToArray();

            string glueText = String.Join(" ", reverseWord);
            string reverseSentence = new string(glueText.ToCharArray().Reverse().ToArray());
            Console.WriteLine(reverseSentence);


            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                consoleMenu.Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");

        }
    }
}
