using System;
using System.Collections.Generic;
using System.Linq;

namespace client
{
    // Uses Naive Search with .NET's LINQ for pattern matching
    // https://www.geeksforgeeks.org/naive-algorithm-for-pattern-searching/
    public class NaiveLinqSearcher : ISearcher
    {
        public string[] Search(string text, string pattern)
        {
            string[] textWords = text.Split(' ');
            string[] patternWords = pattern.Split(' ');

            return (
                from patternWord in patternWords 
                from word in textWords 
                where !string.Equals(word, patternWord, StringComparison.CurrentCulture)
                select word).Distinct().ToArray();
        }   
    }
}