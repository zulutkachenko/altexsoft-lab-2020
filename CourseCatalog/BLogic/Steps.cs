using System;

namespace RecipeCatalog.BLogic
{
    [Serializable]
    public class Steps
    {
        public int Number { get; set; }

        public string Instruction { get; set; }

        public Steps(int number, string instruction)
        {
            Number = number;
            Instruction = instruction;
        }
    }
}