using API.Data.Repository.Interfaces;
using API.Models.Entities;
using API.Service.Interfaces;

namespace API.Service
{
    public class ServiceMovement : IServiceMovement
    {
        private readonly IMovementRepository _repository;

        public ServiceMovement(IMovementRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movement> GetAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Movement>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public void Post(Movement item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(Movement item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
