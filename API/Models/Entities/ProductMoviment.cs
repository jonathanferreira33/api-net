namespace API.Models.Entities
{
    public class ProductMoviment
    {
        public int ProductID { get; set; }
        public int MovementID { get; set; }
        public Product Product { get; set; }
        public Movement Movement { get; set; }
    }
}
