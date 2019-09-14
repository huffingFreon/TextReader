using System;
using System.IO;

namespace TextReader
{
    class TextReader
    {
        public static void Main()
        {
            string strPath = @"e:\Classes\CSCI 2910\Lab 2\TheMythOfSisyphus.txt";
            FileInfo file = new FileInfo(strPath);

            string text = File.ReadAllText(strPath);
            string moreText = "Here,.,.,,,..,. is. a, sentence. with. too. much. punctuation.";
            string[] symbols = { ".", "," };

            using(StreamReader sr = file.OpenText())
            {
                var s = "";
                while((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
