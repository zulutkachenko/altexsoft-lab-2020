using System;
using System.IO;
using System.Linq;

namespace altexsoft_lab_2020
{
    class reverse
    {
        mainMenu consoleMenu = new mainMenu();
        public void reverseText()
        {
            Console.Clear();
            string[] sent = File.ReadAllText(@"textSample.txt").Split('.'); // открываем файл и разбиваем массив
            string sss = new string(sent[2]);
            string[] qqq = sss.Split(' ');
            string[] rev = qqq.Reverse().ToArray();

            string ffr = String.Join(" ", rev);
            string rev1 = new string(ffr.ToCharArray().Reverse().ToArray());
            Console.WriteLine(rev1);


            Console.WriteLine("\nTo return to the main menu press <Q> and <ENTER>/Что бы вернутся в главное меню нажмите <Q> и <ENTER>");
            string exitToMainMenu = Console.ReadLine();
            if (exitToMainMenu == "Q")
                consoleMenu.Main();
            else
                Console.WriteLine("You entered an invalid character/Вы ввели недопустимый символ!");

        }
    }
}
