using API.Enums;

namespace API.Models.Entities
{
    public class Employee : BaseEntity
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public EmployeeOffice Office { get; set; }
        public List<Movement> Movements { get; set; }
        public decimal Remuneration { get; set; }
        public List<Vacation> Vacation { get; set; }
    }
}