using API.Models.Entities;

namespace API.Service.Interfaces
{
    public interface IServiceProduct : IBase<Product>
    {
        Task<IEnumerable<Product>> GetProductsAvailableAsync();
    }
}
