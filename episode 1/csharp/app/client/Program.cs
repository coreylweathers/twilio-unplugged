using System;
using System.Diagnostics;

namespace client
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*string text = "I like cheese";
            string pattern = "like";*/
            string text = "I am using HackerRank to improve programming";
            string pattern = "am HackerRank to improve";
            Stopwatch sw = new Stopwatch();

            sw.Start();
            string[] results = FindMissingWords(text, pattern);
            sw.Stop();
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }

            Console.WriteLine($"Elapsed Time: {sw.Elapsed}");
        }

        static string[] FindMissingWords(string text, string pattern)
        {
            ISearcher searcher = new KmpSearcher();
            return searcher.Search(text, pattern);
        }
    }
}
