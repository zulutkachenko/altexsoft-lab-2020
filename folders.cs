using System;
using System.IO;

namespace Altexsoft_lab_2020
{
    class FoldersName
    {
        NavMenu consoleMenu = new NavMenu();
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

            consoleMenu.closeMenu();
        }
    }
}