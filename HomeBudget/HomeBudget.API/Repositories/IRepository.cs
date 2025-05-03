namespace HomeBudget.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllIncludesAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdIncludesAsync(Guid id);
        Task<T> GetByNameAsync(string name);
        Task<T> GetByNameIncludesAsync(string name);
        Task<T> GetByEmailAsync(string email);
        Task<T> GetByEmailIncludesAsync(string email);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
