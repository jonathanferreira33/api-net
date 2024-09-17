using API.Enums;

namespace API.Models.DTOs
{
    public class EmployeePutDTO
    {
        public int RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public EmployeeOffice Office { get; set; }
        public decimal Remuneration { get; set; }

    }
}
