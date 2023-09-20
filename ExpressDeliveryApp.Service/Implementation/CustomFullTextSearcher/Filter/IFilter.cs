namespace ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Filter;

public interface IFilter
{
    IEnumerable<string> Filter(IEnumerable<string> tokens);
}