namespace ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Tokenizers;

public class WhiteSpaceTokenizer : ITokenizer
{
    public IEnumerable<string> Tokenize(string text)
    {
        return text.Split(' ');
    }
}