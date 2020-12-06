using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Formal_languages
{
    public class LexemeClass
    {
        public string Name { get; set; }

        public FiniteStateMachine Machine { get; set; }

        public int Priority { get; set; }

        public LexemeClass() { }

        public LexemeClass(string name, FiniteStateMachine machine, int priority)
        {
            this.Name = name;
            this.Machine = machine;
            this.Priority = priority;
        }

        public LexemeClass(string fileName)
        {
            List<string> token = FileManager.ReadAllLines(fileName);

            this.Name = token[0];
            this.Machine = new FiniteStateMachine(token[1]);
            this.Priority = int.Parse(token[2]);
        }
    }
}
