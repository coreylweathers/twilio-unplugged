using System.IO;

namespace client
{
    public interface ISearcher
    {
        string[] Search(string text, string pattern);
    }
}