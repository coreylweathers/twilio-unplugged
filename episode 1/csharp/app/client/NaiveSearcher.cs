using System;
using System.Collections.Generic;

namespace client
{
    // Uses Naive Search algorithm for pattern matching
    // https://www.geeksforgeeks.org/naive-algorithm-for-pattern-searching/
    public class NaiveSearcher : ISearcher
    {
        public string[] Search(string text, string pattern)
        {
            List<string> results = new List<string>();
            
            string[] textWords = text.Split(' ');
            string[] patternWords = pattern.Split(' ');

            foreach (string patternWord in patternWords)
            {
                foreach (string word in textWords)
                {
                    if (!string.Equals(word, patternWord, StringComparison.CurrentCulture) && !results.Contains(word))
                    {
                        results.Add(word);
                    }
                }
            }

            return results.ToArray();
        }
    }
}