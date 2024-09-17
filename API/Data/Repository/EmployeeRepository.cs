using API.Data.DataAccess;
using API.Data.Repository.Interfaces;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> Delete<Employee>(Task<Employee> employeeDel)
        {
            _context.Remove(employeeDel);
            return SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = _context.Employees.Include(x => x.Movements).ToListAsync();
            return await employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = _context.Employees
                .Include(x=> x.Movements)
                .ThenInclude(x => x.Products)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return await employee;
        }
    }
}
