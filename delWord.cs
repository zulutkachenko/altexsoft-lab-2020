using System;
using System.IO;

namespace Altexsoft_lab_2020
{
    class DelWord
    {
        NavMenu consoleMenu = new NavMenu();
        public void words()
        {


            string openFile = consoleMenu.EnterFileName(); // open file
            Console.WriteLine("Please enter the original file name/ Введите название оригинального файл для его сохранениея");
            File.WriteAllText(Console.ReadLine() + ".txt", openFile); // save original file

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

            consoleMenu.closeMenu();
        }
    }
}
