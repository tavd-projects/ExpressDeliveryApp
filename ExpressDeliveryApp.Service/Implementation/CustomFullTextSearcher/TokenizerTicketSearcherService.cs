using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.Repository.Interfaces;
using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Filter;
using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Tokenizers;
using ExpressDeliveryApp.Service.Interfaces;

namespace ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher;

public class TokenizerTicketSearcherService : ITicketSearcherService
{
    private readonly ITokenizer _tokenizer;
    private readonly IFilter _filter;
    private readonly ITicketRepository _ticketRepository;

    public TokenizerTicketSearcherService(ITokenizer tokenizer, IFilter filter, ITicketRepository ticketRepository)
    {
        _tokenizer = tokenizer;
        _filter = filter;
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> SearchAsync(string text)
    {
        IEnumerable<string> inputFilteredTokens = TokenizeAndFilter(text);
        
        var tickets = await _ticketRepository.GetAllAsync();
        var searchResults = new List<SearchResult<Ticket>>();
        
        foreach (var ticket in tickets)
        {
            IEnumerable<string> outputFilteredTokens = TokenizeAndFilter(ticket.ToString());
            var intersect = inputFilteredTokens.Intersect(outputFilteredTokens);
            
            if (intersect.Count() < 0)
                continue;
            
            searchResults.Add(new SearchResult<Ticket>()
            {
                Entity = ticket,
                Score = intersect.Count()
            });
        }

        return searchResults.OrderByDescending(x => x.Score).Select(x => x.Entity);
    }
    public IEnumerable<string> TokenizeAndFilter(string text)
    {
        return _filter.Filter(_tokenizer.Tokenize(text));
    }
}