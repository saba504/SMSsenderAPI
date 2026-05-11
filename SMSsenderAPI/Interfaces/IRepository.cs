namespace SMSsenderAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Existed(int id);
    }
}
