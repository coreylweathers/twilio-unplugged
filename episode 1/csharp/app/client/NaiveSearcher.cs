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

            // Create a collection to hold the results
            List<string> results = new List<string>();
            
            // Split the text into an array
            string[] textWords = text.Split(' ');

            // Split the pattern into an array
            string[] patternWords = pattern.Split(' ');

            // Foreach pattern word
            foreach (string patternWord in patternWords)
            {
                // Foreach word in the text
                foreach (string word in textWords)
                {
                    // If the text word isn't equal to pattern word add to the results collection
                    if (!string.Equals(word, patternWord, StringComparison.CurrentCulture) && !results.Contains(word))
                    {
                        results.Add(word);
                    }
                }
            }

            // return the results collection as an array
            return results.ToArray();
        }
    }
}