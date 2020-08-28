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
            string[] openFile = consoleMenu.EnterFileName().Split('.'); // открываем файл и разбиваем массив
            string secondSentence = new string(openFile[2]);
            string[] splitSentence = secondSentence.Split(' ');
            string[] reverseWord = splitSentence.Reverse().ToArray();

            string glueText = String.Join(" ", reverseWord);
            string reverseSentence = new string(glueText.ToCharArray().Reverse().ToArray());
            Console.WriteLine(reverseSentence);

            consoleMenu.closeMenu();
        }
    }
}
