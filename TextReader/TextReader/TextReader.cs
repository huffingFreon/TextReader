using System;
using System.IO;

namespace TextReader
{
    class TextReader
    {
        public static void Main()
        {
            string strPath = @"e:\Classes\CSCI 2910\Lab 2\TheMythOfSisyphus.txt";

            string text = File.ReadAllText(strPath);
            string moreText = "Here,.,.,,,..,. is. a, sentence. with. too. much. punctuation.";
            string[] symbols = { ".", "," };

            Console.WriteLine(Sentence.RemoveChars(moreText, symbols));
        }
    }
}
