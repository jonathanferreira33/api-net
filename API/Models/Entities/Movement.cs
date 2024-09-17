namespace API.Models.Entities
{
    public class Movement : BaseEntity
    {
        public List<Product> Products { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}