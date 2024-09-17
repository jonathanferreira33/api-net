using API.Data.Repository.Interfaces;
using API.Models.Entities;
using API.Service.Interfaces;

namespace API.Service
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProductRepository _repository;
        public ServiceProduct(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<IEnumerable<Product>> GetProductsAvailableAsync()
        {
            return _repository.GetProductsAvailableAsync();
        }

        public void Post(Product item)
        {
            _repository.Add(item);
        }

        public Task<bool> Put(Product item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {
           return await _repository.SaveChangesAsync();
        }
    }
}
