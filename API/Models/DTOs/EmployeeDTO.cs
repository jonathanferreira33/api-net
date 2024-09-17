using API.Enums;

namespace API.Models.DTOs
{
    public class EmployeeDTO
    {
        public int RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public EmployeeOffice Office { get; set; }
        public List<MovementDTO> Movements { get; set; }
    }
}