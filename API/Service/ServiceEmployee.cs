using API.Data.Repository;
using API.Data.Repository.Interfaces;
using API.Models.DTOs;
using API.Models.Entities;
using API.Service.Interfaces;

namespace API.Service
{
    public class ServiceEmployee : IServiceEmployee
    {
        private readonly IEmployeeRepository _repository;

        public ServiceEmployee(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            var employeeDel = _repository.GetByIdAsync(id);
            return await _repository.Delete(employeeDel);
        }

        public Task<Employee> GetAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }


        public Task<bool> Put(Employee item)
        {
            
            _repository.Update(item);

            return SaveChanges();
        }

        public void Post(Employee item)
        {
            _repository.Add(item);
        }

        public async Task<bool> SaveChanges()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}
