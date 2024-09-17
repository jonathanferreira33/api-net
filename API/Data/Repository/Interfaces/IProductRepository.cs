using API.Models.Entities;

namespace API.Data.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAvailableAsync();
    }
}
