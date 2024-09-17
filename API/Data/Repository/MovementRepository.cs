using API.Data.DataAccess;
using API.Data.Repository.Interfaces;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class MovementRepository : BaseRepository, IMovementRepository
    {
        private readonly AppDbContext _context;

        public MovementRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Movement> GetByIdAsync(int id)
        {
            var movement = _context.Movements.Include(x => x.Products).Where(x => x.Id == id).FirstOrDefaultAsync();
            return await movement;
        }

        public async Task<IEnumerable<Movement>> GetAllAsync()
        {
            var movements = _context.Movements.Include(x => x.Products).ToListAsync();
            return await movements;
        }
    }
}
