namespace API.Models.DTOs
{
    public class MovementDTO
    {
        public int MovimentNumber { get; set; }
        public List<ProductDTO> Products { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
