using API.Models.Entities;

namespace API.Data.Repository.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<bool> Delete<T>(Task<T> employeeDel);
    }
}
