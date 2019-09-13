using System;
using System.Collections.Generic;

namespace TextReader
{
    public static class Sentence
    {

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

        public static string RandomSentence(string randFileText)
        {
            List<string> allSentences = new List<string>();
            allSentences = AllSentences(randFileText);

            Random rand = new Random();
            int iRandom = rand.Next(0, (allSentences.Count - 1));

            string strRandom = allSentences[iRandom];

            return strRandom;
        }

        public static int WordCount(string countText)
        {
            int iWords; 
            List<string> countSentences = new List<string>();
            string[] moreSentences = countText.Split(' ');

            foreach(string sentence in moreSentences)
            {
                countSentences.Add(sentence);
            }

            iWords = countSentences.Count;

            return iWords;
        }

        //Made more sense to use a string array rather than char, so we could utilize string.Empty to get rid of unnecessary whitespace left by removed characters. 
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
