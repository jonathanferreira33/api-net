namespace API.Service.Interfaces
{
    public interface IBase<T>
    {
        public void Post(T item);
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<bool> Delete(int id);
        public Task<bool> Put(T item);
        public Task<bool> SaveChanges();
    }
}
