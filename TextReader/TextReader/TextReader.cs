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
            string strTest = "the quick brown fox jumps over the lazy dog";

            Words word = new Words(strTest);

            Console.WriteLine(word.CharOccurrence()['e']);
        }
    }
}
