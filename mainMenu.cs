using System;

namespace altexsoft_lab_2020
{
    class mainMenu
    {
        public void Main()
        {
            countWord countWord = new countWord();
            reverse rev = new reverse();
            delWord delWord = new delWord();
            foldersName foldersName = new foldersName();
            int i;
            {

                {
                    Console.Write("Меню:\n1) Remove character/word from text file / Удаление символа/слова из текстового файла \n2) Print the number of words in a text file / Вывести колчиство слов в текстовом файле \n3) Flip the third sentence / Перевернуть третье предложение \n4) File system mapping / Отображение файловой системы \n\n Your choice / Ваше решение: ");
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

    }
}
