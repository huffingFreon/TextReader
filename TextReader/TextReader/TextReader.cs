///////////////////////////////////////////////////////////
///
/// Project: Lab 2 
/// File Name: TextReader.cs
/// Description: Driver class for demonstration of Sentence and Word class capabilities. 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: September 13, 2019
/// 
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;

namespace TextReader
{
    class TextReader
    {
        /// <summary>Defines the entry point of the application.</summary>
        public static void Main()
        {
            string strPath = @"e:\Classes\CSCI 2910\Lab 2\TheMythOfSisyphus.txt";                   //Will have to manually change path of text file, could not get relative paths to cooperate
            string fullText = File.ReadAllText(strPath);                                            //String of the entirety of the text file
            FileInfo file = new FileInfo(strPath);
            Words words = new Words(file);

            int iUserOption = 0;

            try
            {
                Words word = new Words(file);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File specified in code not found");
                Environment.Exit(1);
            }

            Console.WriteLine("Menu" + "\n-------------" + "\n1.) Return a random sentence from the file" + "\n2.) Return number of words in a random sentence" 
                + "\n3.) Return full text without specified characters" + "\n4.) Return how many times a word appears in the full text" + 
                "\n5.) Return how many times a letter appears in the full text\n\nEnter an option to continue: ");

            string line = Console.ReadLine();

            try
            {
                iUserOption = Convert.ToInt32(line);
            }
            catch(FormatException)
            {
                Console.WriteLine("Incorrect form of input");
                Environment.Exit(1);
            }

            switch(iUserOption)
            {
                case 1:
                    {
                        Console.WriteLine(Sentence.RandomSentence(fullText));
                        break;
                    }
                case 2:
                    {
                        string randomSentence = Sentence.RandomSentence(fullText);
                        randomSentence = randomSentence.TrimStart();                                //Removing leading and trailing whitespace so as not to confuse Split(' ') in WordCount()

                        Console.WriteLine("The sentence: " + randomSentence + "\n has " + Sentence.WordCount(randomSentence) + " words in it.");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Which characters would you like to remove from the text?\nPress enter after each character and type \"done\" when you are finished:\n ");
                        List<string> punctuationList = new List<string>();                          //List for dynamic number of characters user can remove
                        while(line != "done")
                        {
                            line = Console.ReadLine();
                            if(line.Length == 1)
                            {
                                punctuationList.Add(line);
                            }
                            else
                            {
                                Console.WriteLine("More than one character entered at a time");
                            }
                        }

                        string[] punctuation = punctuationList.ToArray();
                        Console.WriteLine(Sentence.RemoveChars(fullText, punctuation));
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Type a word which you would like to count the occurrences of: ");
                        line = Console.ReadLine().ToLower();

                        Console.WriteLine("\"" + line + "\" appears in the full text " + words.Occurrence()[line] + " times");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Type a single character which you would like to count the occurrences of: ");

                        string inputStr = Console.ReadLine();
                        
                        while(inputStr.Length > 1)
                        {
                            Console.WriteLine("More than one character entered at a time");
                            inputStr = Console.ReadLine();
                        }

                        char inputChar = inputStr.ToCharArray()[0];

                        try
                        {
                            Console.WriteLine(inputChar.ToString() + " appears in the full text " + words.CharOccurrence()[inputChar] + " times");
                        }
                        catch(KeyNotFoundException)
                        {
                            Console.WriteLine(inputChar.ToString() + " appears in the full text 0 times");
                        }
                        break;
                    }
            }
        }
    }
}
