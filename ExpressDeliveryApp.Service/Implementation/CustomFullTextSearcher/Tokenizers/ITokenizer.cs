namespace ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Tokenizers;

public interface ITokenizer
{
    public IEnumerable<string> Tokenize(string text);
}