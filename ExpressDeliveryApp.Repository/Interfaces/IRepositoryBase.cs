namespace ExpressDeliveryApp.Repository.Interfaces;

public interface IRepositoryBase<TEntity>
{
    Task<Guid> CreateAsync(TEntity entity);
    Task<TEntity> GetAsync(Guid guid);
    Task UpdateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task DeleteAsync(TEntity entity);
}