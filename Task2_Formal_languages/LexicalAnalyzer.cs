using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Formal_languages
{
    class LexicalAnalyzer
    {
        public static List<KeyValuePair<string, string>> Token(List<LexemeClass> lexemeClasses, string input)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            int skip = 0;
            while (skip < input.Length)
            {
                string currentLexemeClass = String.Empty;
                int currentPriority = 0;
                int maxLength = 0;

                foreach (LexemeClass lexemeClass in lexemeClasses)
                {
                    KeyValuePair<bool, int> temp = lexemeClass.Machine.MaxString(input, skip);
                    if (temp.Key)
                    {
                        if (maxLength < temp.Value)
                        {
                            currentLexemeClass = lexemeClass.Name;
                            currentPriority = lexemeClass.Priority;
                            maxLength = temp.Value;
                        }
                        else if (maxLength == temp.Value && currentPriority < lexemeClass.Priority)
                        {
                            currentLexemeClass = lexemeClass.Name;
                            currentPriority = lexemeClass.Priority;
                            maxLength = temp.Value;
                        }
                    }
                }

                if (maxLength > 0)
                {
                    result.Add(new KeyValuePair<string, string>(currentLexemeClass, input.Substring(skip, maxLength)));
                    skip += maxLength;
                }
                else
                {
                    result.Add(new KeyValuePair<string, string>("ERROR", skip.ToString()));
                    skip++;
                }
            }
            return result;
        }
    }
}
