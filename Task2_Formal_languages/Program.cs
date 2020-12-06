using System;
using System.Collections.Generic;

namespace Task2_Formal_languages
{
    class Program
    {
        static void Main(string[] args)
        {
            LexemeClass id = new LexemeClass("ID.txt");
            LexemeClass kw = new LexemeClass("KW.txt");
            LexemeClass intt = new LexemeClass("INT.txt");
            LexemeClass op = new LexemeClass("OP.txt");
            LexemeClass booll = new LexemeClass("BOOL.txt");
            LexemeClass special = new LexemeClass("SPECIAL.txt");
            LexemeClass whitespace = new LexemeClass("WHITESPACE.txt");
            List<LexemeClass> lexemeClasses = new List<LexemeClass>();
            lexemeClasses.Add(id);
            lexemeClasses.Add(kw);
            lexemeClasses.Add(intt);
            lexemeClasses.Add(op);
            lexemeClasses.Add(booll);
            lexemeClasses.Add(special);
            lexemeClasses.Add(whitespace);

            List<KeyValuePair<string, string>> result = LexicalAnalyzer.Token(lexemeClasses, "public i1=1");

            foreach (KeyValuePair<string, string> res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}
