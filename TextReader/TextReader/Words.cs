///////////////////////////////////////////////////////////
///
/// Project: Lab 2 
/// File Name: Words.cs
/// Description: Instantiated class with utilities for creating and manipulating a list of individual words. 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: September 13, 2019
/// 
///////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.IO;

namespace TextReader
{
    /// <summary>Instantiated class with utilities for creating and manipulating a list of individual words.</summary>
    public class Words
    {
        public List<string> wordList = new List<string>();

        /// <summary>Initializes a new instance of the <see cref="Words"/> class using an existing List of strings.</summary>
        /// <param name="existingList">The existing list.</param>
        public Words(List<string> existingList)
        {
            foreach(var v in existingList)
            {
                wordList.Add(v.ToLower());
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Words"/> class using the information from a text file</summary>
        /// <param name="file">The file whose text is to be read</param>
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
                wordList.Add(word.ToLower());
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Words"/> class using a string of words.</summary>
        /// <param name="allText">The string to be separated into words</param>
        public Words(string allText)
        {
            string[] moreWords = allText.Split(' ');

            foreach(string word in moreWords)
            {
                wordList.Add(word.ToLower());
            }
        }

        /// <summary>Returns a dictionary containing each unique word in the text and a count of how many times it was used within</summary>
        /// <returns>Dictionary containing each unique word in the text and a count of how many times it was used within</returns>
        public Dictionary<string, int> Occurrence()
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            string fullText = "";

            foreach(string word in wordList)                                                //Putting words back into a string to be used with RemoveChars()
            {
                fullText += word + " ";
            }

            string[] punctuation = { ".", ",", "!", "?", "\'", "\"", ":", ";" };            //List of punctuation to be removed from the string 
            string fullTextNoPunc = Sentence.RemoveChars(fullText, punctuation);

            string[] noPunctuation = fullTextNoPunc.Split(' ');                             //Breaking the full text without punctuation back down into words

            foreach(string word in noPunctuation)
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

        /// <summary>  Counts the number of occurrences a character makes within the full text and returns a Dictionary indexing this</summary>
        /// <returns>Dictionary indexing the number of occurrences each character makes within the full text</returns>
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
