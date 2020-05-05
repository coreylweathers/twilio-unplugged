using System;
using System.Collections.Generic;
using System.Linq;

namespace client
{
    // Uses the Knuth-Morris-Pratt algorithm for pattern matching to find mismatches
    // https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
    public class KmpSearcher : ISearcher
    {
        public string[] Search(string text, string pattern)
        {
            // Create collection to hold words
            List<string> words = new List<string>();

            string[] patterns = pattern.Split(' ');
            foreach (var currentPattern in patterns)
            {
                bool matched = false;
                
                // Build Longest-Prefix-Suffix Array
                int[] lpsArray = BuildLPSArray(currentPattern);

                // Create iterators
                int i = 0, j = 0, start = 0;

                // Process the text
                while (i < text.Length)
                {
                    // If pattern letter == text letter move forward
                    if (currentPattern[j] == text[i])
                    {
                        j++;
                        i++;
                    }

                    // If pattern has been completely compared to text, go back one letter
                    if (j == currentPattern.Length)
                    {
                        matched = true;
                        j = lpsArray[j - 1];
                    }
                    // Else if we're not at the end of the text & pattern letter != text letter
                    else if (i < text.Length && currentPattern[j] != text[i])
                    {
                        // If current character is space and pattern iterator hasn't moved, add word to collection
                        if (char.IsWhiteSpace(text[i]))
                        {
                            string currentWord = text.Substring(start, i - start);
                            if (matched == false && !words.Contains(currentWord) && !patterns.Contains(currentWord))
                            {
                                words.Add(currentWord);
                            }

                            start = i + 1;
                        }

                        // If pattern has been completely compared to text, go back one letter
                        if (j != 0)
                        {
                            j = lpsArray[j - 1];
                        }
                        // Else keep processing text
                        else
                        {
                            i++;
                        }

                        if (matched)
                            matched = false;
                    }
                }

                // If last word doesn't match pattern 
                string lastWord = text.Substring(start, i - start);
                if (i == text.Length && i != j && matched == false && !words.Contains(lastWord) && !patterns.Contains(lastWord))
                {
                    words.Add(text.Substring(start, i - start));
                }
            }

            return words.ToArray();
        }

        private int[] BuildLPSArray(string pattern)
        {
            int suffixLength = 0;
            int[] lpsArray = new int[pattern.Length];

            // First position is always set to 0
            lpsArray[0] = 0;

            // Loop through pattern
            int i = 1;
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[suffixLength])
                {
                    suffixLength++;
                    lpsArray[i] = suffixLength;
                    i++;
                }
                else
                {
                    if (suffixLength != 0)
                    {
                        suffixLength = lpsArray[suffixLength - 1];
                    }
                    else
                    {
                        lpsArray[i] = suffixLength;
                        i++;
                    }
                }
            }

            return lpsArray;
        }
    }
}