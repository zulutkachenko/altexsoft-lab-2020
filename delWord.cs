using System;
using System.IO;

namespace Altexsoft_lab_2020
{
    class DelWord
    {
        NavMenu consoleMenu = new NavMenu();
        public void words ()
        {
                if (System.IO.File.Exists(@"textSampled.txt"))
                Console.WriteLine("\nOpen file / Открываем файл...\n");
                else
                    Console.WriteLine("File <textSampled.txt> not found / Файл <textSampled.txt> не найден");

            string openFile = File.ReadAllText(@"textSampled.txt"); // open file
            File.WriteAllText(@"textSampleOrigin.txt", openFile); // save original file

            Console.Clear();
            Console.WriteLine("\nEnter the word/character you want to remove from the file / Введите слово/символ, которое хотите удалить из файла:");
            string deleteWord = Console.ReadLine();

            if (openFile.Contains(deleteWord))
            {
                string textDel = openFile.Replace(deleteWord, "");
                File.WriteAllText(@"textDelete.txt", textDel);
                Console.WriteLine("OK!");
            }
            else
                Console.WriteLine($"\nThe word {deleteWord} does not exist in the word document / Слова {deleteWord} НЕ СУЩЕСТВУЕТ в текстовом документе!");


            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                consoleMenu.Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");
        }
    }
}
