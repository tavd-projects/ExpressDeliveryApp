namespace ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Filter;

public class LowerCaseFilter : IFilter
{
    public IEnumerable<string> Filter(IEnumerable<string> tokens)
    {
        return tokens.Select(x => x.ToLower());
    }
}