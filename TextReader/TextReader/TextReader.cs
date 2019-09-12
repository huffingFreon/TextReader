using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextReader
{
    class TextReader
    {
        public static void Main()
        {
            string path = @"e:\Classes\CSCI 2910\Lab 2\TheMythOfSisyphus.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
