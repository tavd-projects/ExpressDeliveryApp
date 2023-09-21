using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.Repository.Interfaces;
using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Filter;
using ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher.Tokenizers;
using ExpressDeliveryApp.Service.Interfaces;

namespace ExpressDeliveryApp.Service.Implementation.CustomFullTextSearcher;

public class TokenizedTicketSearcherService : ITicketSearcherService
{
    private readonly IFilter _filter;
    private readonly ITicketRepository _ticketRepository;
    private readonly ITokenizer _tokenizer;

    public TokenizedTicketSearcherService(ITokenizer tokenizer, IFilter filter, ITicketRepository ticketRepository)
    {
        _tokenizer = tokenizer;
        _filter = filter;
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> SearchAsync(string text)
    {
        var inputFilteredTokens = TokenizeAndFilter(text);

        var tickets = await _ticketRepository.GetAllAsync();
        var searchResults = new List<SearchResult<Ticket>>();

        foreach (var ticket in tickets)
        {
            var outputFilteredTokens = TokenizeAndFilter(TicketToIndexString(ticket));
            var intersect = inputFilteredTokens.Intersect(outputFilteredTokens);

            if (!intersect.Any())
                continue;

            searchResults.Add(new SearchResult<Ticket>
            {
                Entity = ticket,
                Score = intersect.Count()
            });
        }

        return searchResults.OrderByDescending(x => x.Score).Select(x => x.Entity);
    }

    private string TicketToIndexString(Ticket ticket)
    {
        return string.Join(' ', ticket.CancelReason, ticket.Status, ticket.Description, ticket.CustomerName,
            ticket.WeightKg,
            ticket.СargoСollectionTime, ticket.Id);
    }

    public IEnumerable<string> TokenizeAndFilter(string text)
    {
        return _filter.Filter(_tokenizer.Tokenize(text));
    }

    public class SearchResult<TEntity>
    {
        public int Score { get; init; }
        public TEntity Entity { get; init; }
    }
}