using System;
using System.IO;

namespace altexsoft_lab_2020
{
    class foldersName
    {
        mainMenu consoleMenu = new mainMenu();
        public void folderPath()
        {
            Console.WriteLine("\nEnter the directory: / Введите директорию: ");
            string[] allfolders = Directory.GetDirectories(Console.ReadLine());
            Array.Sort(allfolders); 
            foreach (string folder in allfolders)
            {
                Console.WriteLine(Guid.NewGuid() + " | " + folder);
            }

            Console.WriteLine("\nEnter the directory to view the files: / Введите директорию, чтобы посмотреть файлы: ");
            string[] AllFiles = Directory.GetFiles(Console.ReadLine(), "*.*", SearchOption.AllDirectories);
            Array.Sort(AllFiles);
            foreach (string filename in AllFiles)
            {
                Console.WriteLine(filename);
            }

            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                consoleMenu.Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");
        }
    }
}