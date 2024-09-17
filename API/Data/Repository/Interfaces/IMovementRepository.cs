using API.Models.Entities;

namespace API.Data.Repository.Interfaces
{
    public interface IMovementRepository
    {
        Task<IEnumerable<Movement>> GetAllAsync();
        Task<Movement> GetByIdAsync(int id);
    }
}
