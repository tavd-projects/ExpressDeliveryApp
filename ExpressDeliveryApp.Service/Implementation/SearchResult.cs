namespace ExpressDeliveryApp.Service.Implementation;

public class SearchResult<TEntity>
{
    public int Score { get; init; }
    public TEntity Entity { get; init; }
}