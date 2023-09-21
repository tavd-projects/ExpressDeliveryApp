using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher;
using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Filter;
using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Tokenizers;
using ExpressDeliveryApp.Service.Interfaces;

namespace ExpressDeliveryApp.Extensions;

public static class FullTextSearchExtensions
{
    public static IServiceCollection ConfigureAndAddTextSearch(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFilter, LowerCaseFilter>();
        serviceCollection.AddScoped<ITokenizer, WhiteSpaceTokenizer>();
        serviceCollection.AddScoped<ITicketSearcherService, TokenizedTicketSearcherService>();

        return serviceCollection;
    }
}