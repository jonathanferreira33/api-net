namespace API.Models.DTOs
{
    public class MovementRequestDTO
    {
        public List<ProductDTO> Products { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
