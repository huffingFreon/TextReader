using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextReader
{
    public class Words
    {
        public List<string> wordList = new List<string>(); 

        public Words(List<string> existingList)
        {
            foreach(var v in existingList)
            {
                wordList.Add(v);
            }
        }

        public Words(FileInfo file)
        {
            string strText = "";
            string[] words;

            using(StreamReader sr = file.OpenText())
            {
                var s = "";
                while((s = sr.ReadLine()) != null)
                {
                    strText += s;
                }
            }

            words = strText.Split(' ');

            foreach(string word in words)
            {
                wordList.Add(word);
            }
        }

        public Words(string allText)
        {
            string[] moreWords = allText.Split(' ');

            foreach(string word in moreWords)
            {
                wordList.Add(word);
            }
        }

        //Use Regex.Matches() within this class
        public Dictionary<string, int> Occurrence()
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            return occurrences;
        }

        //Use Regex.Matches() here too if it works
        public Dictionary<char, int> CharOccurrence()
        {
            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            return charOccurrences;
        }
    }
}
