using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Altexsoft_lab_2020
{
    class NavMenu
    {

        public string EnterFileName()
        {
            Console.WriteLine("Enter file name to open/ Введите название файла, который хотите открыть: \n");
            string fileName = Console.ReadLine();
            List<string> list = new List<string>();
            if (File.Exists(fileName))
            {
                string readFile = File.ReadAllText($@"{fileName}");
                
                list.Add(readFile);
            }
            else
                Console.WriteLine("File not found!");
            string str = string.Join(" ", list);
            return str;

        }
        public void Main()
        {
            CountWord countWord = new CountWord();
            Reverse rev = new Reverse();
            DelWord delWord = new DelWord();
            FoldersName foldersName = new FoldersName();
            int i;
            {

                {

                    Console.Write("Меню:\n1) Remove character/word from text file / Удаление символа/слова из текстового файла \n2) Print the number of words in a text file / Вывести количество слов в текстовом файле \n3) Flip the third sentence / Перевернуть третье предложение \n4) File system mapping / Отображение файловой системы \n\n Your choice / Ваше решение: ");
                    i = int.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            delWord.words();
                            break;
                        case 2:
                            countWord.count();
                            break;
                        case 3:
                            rev.reverseText();
                            break;
                        case 4:
                            foldersName.folderPath();
                            break;
                        default:
                            Console.WriteLine("You pressed something else / Вы нажали что-то другое...");
                            break;
                    }
                    Console.Write("\nPress any key / Нажмите любую клавишу...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void closeMenu()
        {
            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");
        }

    }
}
