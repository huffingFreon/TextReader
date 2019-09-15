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

        public Dictionary<string, int> Occurrence()
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            foreach(string word in wordList)
            {
                if(occurrences.ContainsKey(word))
                {
                    occurrences[word] += 1;
                }
                else
                {
                    occurrences.Add(word, 1);
                }
            }

            return occurrences;
        }

        public Dictionary<char, int> CharOccurrence()
        {
            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            foreach(string word in wordList)
            {
                char[] brokenDownWords = word.ToCharArray();

                foreach(char c in brokenDownWords)
                {
                    if(charOccurrences.ContainsKey(c))
                    {
                        charOccurrences[c] += 1;
                    }
                    else
                    {
                        charOccurrences.Add(c, 1);
                    }
                }
            }

            return charOccurrences;
        }
    }
}
