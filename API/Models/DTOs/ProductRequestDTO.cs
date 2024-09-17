namespace API.Models.DTOs
{
    public class ProductRequestDTO
    {
        public int Amount { get; set; }
        public string EAN { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
    }
}
