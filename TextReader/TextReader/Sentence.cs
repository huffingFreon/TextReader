///////////////////////////////////////////////////////////
///
/// Project: Lab 2 
/// File Name: Sentence.cs
/// Description: Static class with utilities for counting sentences in a word file 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: September 13, 2019
/// 
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace TextReader
{
    /// <summary>Static class with utilities for counting sentences</summary>
    public static class Sentence
    {

        /// <summary>  Takes in a string of the full file text and returns a List of strings separated into sentences</summary>
        /// <param name="fileText">The file text.</param>
        /// <returns>File text separated into sentences.</returns>
        public static List<string> AllSentences(string fileText)
        {
            List<string> allSentences = new List<string>();
            string[] sentences = fileText.Split('.', '!', '?');

            foreach(string sentence in sentences)
            {
                allSentences.Add(sentence);
            }

            return allSentences; 
        }

        /// <summary> Takes in a string of the full file text and returns a random sentence from it.</summary>
        /// <param name="randFileText">The file text</param>
        /// <returns>A random sentence from the larger text within a string</returns>
        public static string RandomSentence(string randFileText)
        {
            List<string> allSentences = new List<string>();
            allSentences = AllSentences(randFileText);

            Random rand = new Random();
            int iRandom = rand.Next(0, (allSentences.Count - 1));

            string strRandom = allSentences[iRandom];

            return strRandom;
        }

        /// <summary>  Takes in  a string of the full file text and returns an integer count of how many words were in it</summary>
        /// <param name="countText">  Text whose words are to be counted</param>
        /// <returns>
        ///   <para>Integer number of how many words were in the provided text.</para>
        /// </returns>
        public static int WordCount(string countText)
        {
            int iWords;
            List<string> countTextList = new List<string>();

            string[] moreSentences = countText.Split(' ');

            foreach (string sentence in moreSentences)
            {
                countTextList.Add(sentence);
            }

            iWords = countTextList.Count;

            return iWords;
        }

        //Made more sense to use a string array rather than char, so we could utilize string.Empty to get rid of unnecessary whitespace left by removed characters. 
        /// <summary>
        /// Removes specified characters from the provided string. Used an array of strings rather than chars so we could utilize string.Empty to get rid of unnecessary whitespace left by removed characters.
        /// </summary>
        /// <param name="toEdit">  The string from which characters will be removed</param>
        /// <param name="toRemove">  Characters whose occurrences will be removed from the string</param>
        /// <returns>The original string sans characters specified for removal</returns>
        public static string RemoveChars(string toEdit, string[] toRemove)
        {
            string strEdited = toEdit; 

            foreach(string symbol in toRemove)
            {
                strEdited = strEdited.Replace(symbol, string.Empty); 
            }

            return strEdited;
        }
    }
}
