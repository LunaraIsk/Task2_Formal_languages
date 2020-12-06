using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2_Formal_languages
{
    public class FiniteStateMachine
    {
        public List<string> Alphabet { get; set; }

        public List<string> States { get; set; }

        public List<string> InitialStates { get; set; }

        public Dictionary<string, Dictionary<string, List<string>>> StateTransitionFunction { get; set; }

        public List<string> FinalStates { get; set; }

        public FiniteStateMachine() { }

        public FiniteStateMachine(List<string> alphabet, List<string> states, List<string> initialStates,
            Dictionary<string, Dictionary<string, List<string>>> stateTransitionFunction, List<string> finalStates)
        {
            this.Alphabet = alphabet;
            this.States = states;
            this.InitialStates = initialStates;
            this.StateTransitionFunction = stateTransitionFunction;
            this.FinalStates = finalStates;
        }

        public FiniteStateMachine(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string json = file.ReadToEnd().Trim();
                FiniteStateMachine temp = JsonConvert.DeserializeObject<FiniteStateMachine>(json);
                this.Alphabet = temp.Alphabet;
                this.States = temp.States;
                this.InitialStates = temp.InitialStates;
                this.FinalStates = temp.FinalStates;
                this.StateTransitionFunction = temp.StateTransitionFunction;
            }
        }

        public KeyValuePair<bool, int> MaxString(string input, int skip)
        {
            bool flag = false;
            int maxLength = 0;

            List<string> currentStates = new List<string>();
            currentStates.AddRange(this.InitialStates);

            if (currentStates.Intersect(this.FinalStates).ToList().Count != 0)
            {
                flag = true;
            }

            for (int i = skip; i < input.Length; i++)
            {
                if (this.Alphabet.Contains(input[i].ToString()))
                {
                    int count = currentStates.Count;
                    for (int j = 0; j < count; j++)
                    {
                        currentStates.AddRange(this.StateTransitionFunction[input[i].ToString()][currentStates[j]]);
                    }

                    currentStates.RemoveRange(0, count);
                    currentStates = currentStates.Distinct().ToList();
                    if (currentStates.Intersect(this.FinalStates).ToList().Count != 0)
                    {
                        flag = true;
                        maxLength = i + 1 - skip;
                    }
                }
                else
                {
                    return new KeyValuePair<bool, int>(flag, maxLength);
                }
            }

            return new KeyValuePair<bool, int>(flag, maxLength);
        }
    }
}
